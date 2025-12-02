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
		internal uint VkCode;
		internal uint ScanCode;
		internal uint Flags;
		internal uint Time;
		internal UIntPtr ExtraInfo;
	}
	
	[StructLayout(LayoutKind.Sequential)]
	internal struct MSG
	{
		internal IntPtr  Hwnd;
		internal uint    Message;
		internal UIntPtr WParam;
		internal IntPtr  LParam;
		internal uint    Time;
		internal POINT   Pt;
		internal uint    LPrivate;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct INPUT
	{
		internal uint type;
		internal DUMMYUNION u;
		
		internal static readonly unsafe int Size = sizeof(INPUT);
		
		internal static INPUT KeybdInput(ushort sc = 0, uint flags = 0, UIntPtr extraInfo = 0, ushort vk = 0, uint time = 0)
			=> new()
			{
				type = Constants.INPUT_KEYBOARD,
				u = new DUMMYUNION { ki = new KEYBDINPUT { Vk = vk, Scan = sc, Flags = flags, Time = time, ExtraInfo = extraInfo } }
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
		internal int X;
		internal int Y;
		internal uint MouseData;
		internal uint Flags;
		internal uint Time;
		internal UIntPtr ExtraInfo;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct KEYBDINPUT
	{
		internal ushort Vk;
		internal ushort Scan;
		internal uint Flags;
		internal uint Time;
		internal UIntPtr ExtraInfo;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct HARDWAREINPUT
	{
		internal uint Msg;
		internal ushort ParamL;
		internal ushort ParamH;
	}
	
	#endregion
	
	#region windef.h
	
	[StructLayout(LayoutKind.Sequential)]
	internal struct POINT
	{
		internal int X;
		internal int Y;
	}

	#endregion
}
