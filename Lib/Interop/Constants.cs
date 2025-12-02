namespace Lib.Interop;

// ReSharper disable InconsistentNaming
public static class Constants
{
	#region winuser.h
	
	internal const int WH_KEYBOARD_LL = 13;
	
	internal const uint WM_QUIT = 0x0012;
	
	internal const uint INPUT_MOUSE    = 0;
	internal const uint INPUT_KEYBOARD = 1;
	internal const uint INPUT_HARDWARE = 2;
	
	internal const ushort KEYEVENTF_EXTENDEDKEY = 0x0001;
	internal const ushort KEYEVENTF_KEYUP       = 0x0002;
	internal const ushort KEYEVENTF_UNICODE     = 0x0004;
	internal const ushort KEYEVENTF_SCANCODE    = 0x0008;
	
	internal const ushort MAPVK_VK_TO_VSC_EX = 4;
	
	internal const ushort LLKHF_EXTENDED = 0x01;
	internal const ushort LLKHF_INJECTED = 0x10;
	internal const ushort LLKHF_UP       = 0x80;
	
	#endregion
	
	internal const ushort VK_CONSUMER_BEGIN = 0xA6; // VK_BROWSER_BACK
	internal const ushort VK_CONSUMER_END   = 0xB7; // VK_LAUNCH_APP2
}