using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Interop;
using static Lib.Interop.Constants;
using static Lib.Interop.Structs;
using Lib.Interop;
using Lib.Interop.SafeHandles;

namespace Lib;

public sealed class TrayIcon : IDisposable
{
	private NOTIFYICONDATAW _nid;
	private readonly List<Item> _items = [];
	
	private int _iconIndex = -1;
	private bool _isVisible;
	
	private readonly uint _id;
	private readonly nint _hwnd;
	private readonly uint _msg;
	
	private Action<int, TrayIcon>? _onLClick;
	private Action<int, TrayIcon>? _onRClick;
	private Action<int, TrayIcon>? _onDClick;
	
	private HwndSourceHook? _messageHandler;
	
	private bool _disposed;
	
	public uint Id => _id;
	
	public TrayIcon(uint id, nint hwnd = 0, uint msg = WM_USER)
	{
		var nid = new NOTIFYICONDATAW();
		if (hwnd == 0) hwnd = LibApp.Hwnd;

		unsafe { nid.cbSize = (uint)sizeof(NOTIFYICONDATAW); }
		nid.hWnd = hwnd;
		nid.uID = id;
		nid.uFlags = NIF_MESSAGE | NIF_STATE;
		nid.uCallbackMessage = msg;
		nid.dwState = NIS_HIDDEN;
		nid.dwStateMask = NIS_HIDDEN;
		
		if (!Shell32.Shell_NotifyIcon(NIM_ADD, ref nid))
		{
			throw new Exception(Marshal.GetLastPInvokeErrorMessage());
		}
		
		_nid = nid;
		_id = id; _hwnd = hwnd; _msg = msg;
	}
	
	public TrayIcon Add(string iconPath, string? tip = null)
	{
		ArgumentException.ThrowIfNullOrWhiteSpace(iconPath);
		
		var hIcon = User32.LoadImage(nint.Zero, iconPath, IMAGE_ICON, 0, 0, LR_LOADFROMFILE | LR_DEFAULTSIZE);
		if (hIcon.IsInvalid)
		{
			throw new Exception(Marshal.GetLastPInvokeErrorMessage());
		}
		
		_items.Add(new Item(hIcon, tip ?? ""));
		return this;
	}
	
	public void Display(int index)
	{
		if ((uint)index >= (uint)_items.Count)
		{
			throw new ArgumentOutOfRangeException(nameof(index));
		}
		
		if (index == _iconIndex)
		{
			Show();
			return;
		}
		
		var flags = NIF_ICON | NIF_TIP | (_isVisible ? 0 : NIF_STATE);
		
		NotifyIcon(_items[index], flags, NIM_MODIFY);
		
		_isVisible = true;
		_iconIndex = index;
	}
	
	public void Show()
	{
		if (!_isVisible) ToggleVisibility();
	}
	
	public void Hide()
	{
		if (_isVisible) ToggleVisibility();
	}
	
	public bool ToggleVisibility()
	{
		NotifyIcon(null!, NIF_STATE, NIM_MODIFY, _isVisible);
		return _isVisible ^= true;
	}
	
	private unsafe void NotifyIcon(Item item, uint uFlags, uint dwMessage, bool hide = false)
	{
		if ((uFlags & NIF_ICON) != 0)
		{
			_nid.hIcon = item.HIcon.DangerousGetHandle();
		}
		
		if ((uFlags & NIF_TIP) != 0)
		{
			const int maxTipBytes = (128 - 1) * sizeof(char); // 128 chars - 1 (null) -> 127 characters (254 bytes)
			int size = Math.Min(item.Tip.Length * 2, maxTipBytes);
			
			fixed (char* dest = _nid.szTip)
			{
				if (size > 0)
				{
					fixed (char* source = item.Tip)
					{
						Buffer.MemoryCopy(source, dest, size, size);
					}
				}
				dest[size / 2] = '\0';
			}
		}
		
		if ((uFlags & NIF_STATE) != 0)
		{
			_nid.dwState = hide ? NIS_HIDDEN : 0;
			_nid.dwStateMask = NIS_HIDDEN;
		}
		
		_nid.uFlags = uFlags;
		
		if (!Shell32.Shell_NotifyIcon(dwMessage, ref _nid))
		{
			throw new Exception(Marshal.GetLastPInvokeErrorMessage());
		}
	}
	
	public TrayIcon OnLeftClick(Action<int, TrayIcon> callback)
	{
		_onLClick = callback;
		EnsureOnMessageInitialized();
		return this;
	}
	
	public TrayIcon OnRightClick(Action<int, TrayIcon> callback)
	{
		_onRClick = callback;
		EnsureOnMessageInitialized();
		return this;
	}
	
	public TrayIcon OnDoubleClick(Action<int, TrayIcon> callback)
	{
		_onDClick = callback;
		EnsureOnMessageInitialized();
		return this;
	}
	
	private void EnsureOnMessageInitialized()
	{
		if (_messageHandler is null && Interlocked.CompareExchange(ref _messageHandler, MessageHandler, null) == null)
		{
			LibApp.OnMessage((int)_msg, _messageHandler);
		}
	}
	
	private nint MessageHandler(nint hwnd, int msg, nint wParam, nint lParam, ref bool __)
	{
		if (wParam != _id || hwnd != _hwnd)
		{
			return 0;
		}
		
		Action<int, TrayIcon>? callback = lParam switch
		{
			WM_LBUTTONDOWN   => _onLClick,
			WM_LBUTTONDBLCLK => _onDClick,
			WM_RBUTTONDOWN   => _onRClick,
			_ => null
		};
		
		callback?.Invoke(_iconIndex, this);
		return 0;
	}
	
	public void Dispose()
	{
		if (Interlocked.CompareExchange(ref _disposed, true, false))
		{
			return;
		}
		
		_ = Shell32.Shell_NotifyIcon(NIM_DELETE, ref _nid);
		
		foreach (var item in _items)
		{
			item.HIcon.Dispose();
		}
		
		if (_messageHandler is not null)
		{
			LibApp.RemoveOnMessage((int)_msg, _messageHandler);
		}
	}
	
	private record Item(HImage HIcon, string Tip);
}
