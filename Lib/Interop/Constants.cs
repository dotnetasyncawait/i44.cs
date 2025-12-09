namespace Lib.Interop;

// ReSharper disable InconsistentNaming
public static class Constants
{
	#region winuser.h
	
	internal const int WH_KEYBOARD_LL = 13;
	internal const int WH_MOUSE_LL    = 14;
	
	internal const uint WM_QUIT = 0x0012;
	
	internal const uint INPUT_MOUSE    = 0;
	internal const uint INPUT_KEYBOARD = 1;
	internal const uint INPUT_HARDWARE = 2;
	
	internal const ushort KEYEVENTF_EXTENDEDKEY = 0x0001;
	internal const ushort KEYEVENTF_KEYUP       = 0x0002;
	internal const ushort KEYEVENTF_UNICODE     = 0x0004;
	internal const ushort KEYEVENTF_SCANCODE    = 0x0008;
	
	internal const ushort MOUSEEVENTF_LEFTDOWN   = 0x0002;
	internal const ushort MOUSEEVENTF_LEFTUP     = 0x0004;
	internal const ushort MOUSEEVENTF_RIGHTDOWN  = 0x0008;
	internal const ushort MOUSEEVENTF_RIGHTUP    = 0x0010;
	internal const ushort MOUSEEVENTF_MIDDLEDOWN = 0x0020;
	internal const ushort MOUSEEVENTF_MIDDLEUP   = 0x0040;
	internal const ushort MOUSEEVENTF_XDOWN      = 0x0080;
	internal const ushort MOUSEEVENTF_XUP        = 0x0100;
	internal const ushort MOUSEEVENTF_WHEEL      = 0x0800;
	internal const ushort MOUSEEVENTF_HWHEEL     = 0x1000;
	
	internal const ushort MAPVK_VK_TO_VSC_EX = 4;
	
	internal const ushort LLKHF_EXTENDED = 0x01;
	internal const ushort LLKHF_INJECTED = 0x10;
	internal const ushort LLKHF_UP       = 0x80;
	
	internal const ushort WM_MOUSEMOVE   = 0x0200;
	internal const ushort WM_LBUTTONDOWN = 0x0201;
	internal const ushort WM_LBUTTONUP   = 0x0202;
	internal const ushort WM_RBUTTONDOWN = 0x0204;
	internal const ushort WM_RBUTTONUP   = 0x0205;
	internal const ushort WM_MBUTTONDOWN = 0x0207;
	internal const ushort WM_MBUTTONUP   = 0x0208;
	internal const ushort WM_MOUSEWHEEL  = 0x020A;
	internal const ushort WM_XBUTTONDOWN = 0x020B;
	internal const ushort WM_XBUTTONUP   = 0x020C;
	internal const ushort WM_MOUSEHWHEEL = 0x020E;
	
	#endregion
	
	#region winuser.rh
	
	internal const ushort XBUTTON1 = 0x0001; 
	internal const ushort XBUTTON2 = 0x0002;
	
	internal const short WHEEL_DELTA = 120;
	
	#endregion
	
	internal const ushort VK_CONSUMER_BEGIN = 0xA6; // VK_BROWSER_BACK
	internal const ushort VK_CONSUMER_END   = 0xB7; // VK_LAUNCH_APP2
}