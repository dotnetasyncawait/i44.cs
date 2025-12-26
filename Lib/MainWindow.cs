using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using Lib.Shared;

namespace Lib;

internal sealed class MainWindow : Window
{
	private readonly Dictionary<int, List<HwndSourceHook>> _onMessageCallbacks = [];
	private readonly HwndSource _hwndSource;
	
	// Docs: The actual hooks are held by a weak reference.
	// Therefore, make sure that you manage the lifetime of your hook delegate.
	private readonly HwndSourceHook _wndProc;
	
	internal nint Hwnd { get; }
	
	public MainWindow()
	{
		Visibility = Visibility.Hidden;
		Hwnd = new WindowInteropHelper(this).EnsureHandle();
		
		_hwndSource = HwndSource.FromHwnd(Hwnd)!;
		_hwndSource.AddHook(_wndProc = WndProc);
	}
	
	internal void OnMessage(int messageId, HwndSourceHook callback)
	{
		ref var callbacks = ref CollectionsMarshal.GetValueRefOrAddDefault(_onMessageCallbacks, messageId, out var exists);
		if (exists)
		{
			callbacks!.Add(callback);
		}
		else
		{
			callbacks = [ callback ];
		}
	}
	
	internal void RemoveOnMessage(int messageId, HwndSourceHook callback)
	{
		if (!_onMessageCallbacks.TryGetValue(messageId, out var list))
		{
			throw new KeyNotFoundException("Message Id not found");
		}
		
		if (!list.Remove(callback))
		{
			throw new Exception("Callback not found");
		}
		
		if (list.Count == 0)
		{
			_onMessageCallbacks.Remove(messageId);
		}
	}
	
	private nint WndProc(nint hwnd, int msg, nint wParam, nint lParam, ref bool handled)
	{
		Debug.WriteLineEx($"hwnd: 0x{hwnd:X}; msg: 0x{msg:X}; wParam: 0x{wParam:X}; lParam: 0x{lParam:X}");

		if (_onMessageCallbacks.TryGetValue(msg, out var handlers))
		{
			foreach (var handler in handlers)
			{
				var res = handler(hwnd, msg, wParam, lParam, ref handled);
				if (handled)
				{
					return res;
				}
			}
		}
		
		return 0;
	}
}