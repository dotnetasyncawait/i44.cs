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
}
