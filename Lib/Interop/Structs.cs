using System;
using System.Runtime.InteropServices;

namespace Lib.Interop;

// ReSharper disable InconsistentNaming
internal static class Structs
{
	#region winuser.h:

	[StructLayout(LayoutKind.Sequential)]
	internal struct KBDLLHOOKSTRUCT
	{
		internal uint  vkCode;
		internal uint  scanCode;
		internal uint  flags;
		internal uint  time;
		internal nuint dwExtraInfo;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	internal struct MSLLHOOKSTRUCT
	{
		internal POINT pt;
		internal uint  mouseData;
		internal uint  flags;
		internal uint  time;
		internal nuint dwExtraInfo;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	internal struct MSG
	{
		internal nint  hwnd;
		internal uint  message;
		internal nuint wParam;
		internal nint  lParam;
		internal uint  time;
		internal POINT pt;
		internal uint  lPrivate;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct INPUT
	{
		internal uint type;
		internal DUMMYUNION u;
		
		internal static readonly unsafe int Size = sizeof(INPUT);
		
		internal static INPUT KeybdInput(ushort sc = 0, uint flags = 0, nuint extraInfo = 0, ushort vk = 0, uint time = 0)
			=> new()
			{
				type = Constants.INPUT_KEYBOARD,
				u = new DUMMYUNION { ki = new KEYBDINPUT { mVk = vk, wScan = sc, dwFlags = flags, time = time, dwExtraInfo = extraInfo } }
			};
		
		internal static INPUT MouseInput(uint data, uint flags, nuint extraInfo, int x = 0, int y = 0, uint time = 0)
			=> new()
			{
				type = Constants.INPUT_MOUSE,
				u = new DUMMYUNION
				{ mi = new MOUSEINPUT { dx = x, dy = y, mouseData = data, dwFlags = flags, time = time, dwExtraInfo = extraInfo } }
			};
	}
	
	[StructLayout(LayoutKind.Explicit)]
	internal struct DUMMYUNION
	{
		[FieldOffset(0)] internal MOUSEINPUT    mi;
		[FieldOffset(0)] internal KEYBDINPUT    ki;
		[FieldOffset(0)] internal HARDWAREINPUT hi;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct MOUSEINPUT
	{
		internal int   dx;
		internal int   dy;
		internal uint  mouseData;
		internal uint  dwFlags;
		internal uint  time;
		internal nuint dwExtraInfo;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct KEYBDINPUT
	{
		internal ushort mVk;
		internal ushort wScan;
		internal uint   dwFlags;
		internal uint   time;
		internal nuint  dwExtraInfo;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct HARDWAREINPUT
	{
		internal uint   uMsg;
		internal ushort wParamL;
		internal ushort wParamH;
	}
	
	#endregion
	
	#region windef.h
	
	[StructLayout(LayoutKind.Sequential)]
	internal struct POINT
	{
		internal int x;
		internal int y;
	}

	#endregion
	
	#region shellapi.h
	
	[StructLayout(LayoutKind.Sequential)]
	internal unsafe struct NOTIFYICONDATAW
	{
		internal uint cbSize;
		internal nint hWnd;
		internal uint uID;
		internal uint uFlags;
		internal uint uCallbackMessage;
		internal nint hIcon;
		
		// Technically, we could use the [MarshalAs(UnmanagedType.ByValTStr, SizeConst = <size>)] attribute for szTip, szInfo,
		// and szInfoTitle, but the default marshaller of the P/Invoke source-generator does not support marshalling string
		// fields.
		internal fixed char szTip[128];
		
		internal uint dwState;
		internal uint dwStateMask;
		internal fixed char szInfo[256];
		internal uint uVersion;
		internal fixed char szInfoTitle[64];
		internal uint dwInfoFlags;
		internal Guid guidItem;
		internal nint hBalloonIcon;
	}
	
	#endregion
}
