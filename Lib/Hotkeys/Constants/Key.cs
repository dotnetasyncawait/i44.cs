namespace Lib.Hotkeys.Constants;

public static class Key
{
	#region Mouse Keys
	
	public const ushort LButton    = 0x0200;
	public const ushort RButton    = 0x0201;
	public const ushort MButton    = 0x0202;
	public const ushort XButton1   = 0x0203;
	public const ushort XButton2   = 0x0204;
	public const ushort WheelUp    = 0x0205;
	public const ushort WheelDown  = 0x0206;
	public const ushort WheelLeft  = 0x0207;
	public const ushort WheelRight = 0x0208;
	
	#region Wheel Multipliers
	
	public const ushort WheelUpX2  = WheelUp | 0x1000;
	public const ushort WheelUpX3  = WheelUp | 0x2000;
	public const ushort WheelUpX4  = WheelUp | 0x3000;
	public const ushort WheelUpX5  = WheelUp | 0x4000;
	public const ushort WheelUpX6  = WheelUp | 0x5000;
	public const ushort WheelUpX7  = WheelUp | 0x6000;
	public const ushort WheelUpX8  = WheelUp | 0x7000;
	public const ushort WheelUpX9  = WheelUp | 0x8000;
	public const ushort WheelUpX10 = WheelUp | 0x9000;
	public const ushort WheelUpX11 = WheelUp | 0xA000;
	public const ushort WheelUpX12 = WheelUp | 0xB000;
	public const ushort WheelUpX13 = WheelUp | 0xC000;
	public const ushort WheelUpX14 = WheelUp | 0xD000;
	public const ushort WheelUpX15 = WheelUp | 0xE000;
	public const ushort WheelUpX16 = WheelUp | 0xF000;
	
	public const ushort WheelDownX2  = WheelDown | 0x1000;
	public const ushort WheelDownX3  = WheelDown | 0x2000;
	public const ushort WheelDownX4  = WheelDown | 0x3000;
	public const ushort WheelDownX5  = WheelDown | 0x4000;
	public const ushort WheelDownX6  = WheelDown | 0x5000;
	public const ushort WheelDownX7  = WheelDown | 0x6000;
	public const ushort WheelDownX8  = WheelDown | 0x7000;
	public const ushort WheelDownX9  = WheelDown | 0x8000;
	public const ushort WheelDownX10 = WheelDown | 0x9000;
	public const ushort WheelDownX11 = WheelDown | 0xA000;
	public const ushort WheelDownX12 = WheelDown | 0xB000;
	public const ushort WheelDownX13 = WheelDown | 0xC000;
	public const ushort WheelDownX14 = WheelDown | 0xD000;
	public const ushort WheelDownX15 = WheelDown | 0xE000;
	public const ushort WheelDownX16 = WheelDown | 0xF000;
	
	public const ushort WheelLeftX2  = WheelLeft | 0x1000;
	public const ushort WheelLeftX3  = WheelLeft | 0x2000;
	public const ushort WheelLeftX4  = WheelLeft | 0x3000;
	public const ushort WheelLeftX5  = WheelLeft | 0x4000;
	public const ushort WheelLeftX6  = WheelLeft | 0x5000;
	public const ushort WheelLeftX7  = WheelLeft | 0x6000;
	public const ushort WheelLeftX8  = WheelLeft | 0x7000;
	public const ushort WheelLeftX9  = WheelLeft | 0x8000;
	public const ushort WheelLeftX10 = WheelLeft | 0x9000;
	public const ushort WheelLeftX11 = WheelLeft | 0xA000;
	public const ushort WheelLeftX12 = WheelLeft | 0xB000;
	public const ushort WheelLeftX13 = WheelLeft | 0xC000;
	public const ushort WheelLeftX14 = WheelLeft | 0xD000;
	public const ushort WheelLeftX15 = WheelLeft | 0xE000;
	public const ushort WheelLeftX16 = WheelLeft | 0xF000;
	
	public const ushort WheelRightX2  = WheelRight | 0x1000;
	public const ushort WheelRightX3  = WheelRight | 0x2000;
	public const ushort WheelRightX4  = WheelRight | 0x3000;
	public const ushort WheelRightX5  = WheelRight | 0x4000;
	public const ushort WheelRightX6  = WheelRight | 0x5000;
	public const ushort WheelRightX7  = WheelRight | 0x6000;
	public const ushort WheelRightX8  = WheelRight | 0x7000;
	public const ushort WheelRightX9  = WheelRight | 0x8000;
	public const ushort WheelRightX10 = WheelRight | 0x9000;
	public const ushort WheelRightX11 = WheelRight | 0xA000;
	public const ushort WheelRightX12 = WheelRight | 0xB000;
	public const ushort WheelRightX13 = WheelRight | 0xC000;
	public const ushort WheelRightX14 = WheelRight | 0xD000;
	public const ushort WheelRightX15 = WheelRight | 0xE000;
	public const ushort WheelRightX16 = WheelRight | 0xF000;
	
	#endregion // Wheel Multipliers
	
	#endregion // Mouse Keys
	
	#region Letters
	
	public const ushort A = 0x001E;
	public const ushort B = 0x0030;
	public const ushort C = 0x002E;
	public const ushort D = 0x0020;
	public const ushort E = 0x0012;
	public const ushort F = 0x0021;
	public const ushort G = 0x0022;
	public const ushort H = 0x0023;
	public const ushort I = 0x0017;
	public const ushort J = 0x0024;
	public const ushort K = 0x0025;
	public const ushort L = 0x0026;
	public const ushort M = 0x0032;
	public const ushort N = 0x0031;
	public const ushort O = 0x0018;
	public const ushort P = 0x0019;
	public const ushort Q = 0x0010;
	public const ushort R = 0x0013;
	public const ushort S = 0x001F;
	public const ushort T = 0x0014;
	public const ushort U = 0x0016;
	public const ushort V = 0x002F;
	public const ushort W = 0x0011;
	public const ushort X = 0x002D;
	public const ushort Y = 0x0015;
	public const ushort Z = 0x002C;
	
	#endregion
	
	#region Numbers
	
	public const ushort Num1 = 0x0002;
	public const ushort Num2 = 0x0003;
	public const ushort Num3 = 0x0004;
	public const ushort Num4 = 0x0005;
	public const ushort Num5 = 0x0006;
	public const ushort Num6 = 0x0007;
	public const ushort Num7 = 0x0008;
	public const ushort Num8 = 0x0009;
	public const ushort Num9 = 0x000A;
	public const ushort Num0 = 0x000B;
	
	#endregion
	
	#region Navigation
	
	public const ushort Escape    = 0x0001;
	public const ushort Enter     = 0x001C;
	public const ushort Tab       = 0x000F;
	public const ushort Space     = 0x0039;
	public const ushort Backspace = 0x000E;
	public const ushort Delete    = 0xE053;
	public const ushort Insert    = 0xE052;
	public const ushort Home      = 0xE047;
	public const ushort End       = 0xE04F;
	public const ushort PageUp    = 0xE049;
	public const ushort PageDown  = 0xE051;
	public const ushort Up        = 0xE048;
	public const ushort Down      = 0xE050;
	public const ushort Left      = 0xE04B;
	public const ushort Right     = 0xE04D;
	
	#endregion
	
	#region Symbols
	
	public const ushort Dash         = 0x000C;
#pragma warning disable CS0108
	public const ushort Equals       = 0x000D;
#pragma warning restore CS0108
	public const ushort LBrace       = 0x001A;
	public const ushort RBrace       = 0x001B;
	public const ushort Backslash    = 0x002B;
	public const ushort SemiColon    = 0x0027;
	public const ushort Apostrophe   = 0x0028;
	public const ushort Grave        = 0x0029;
	public const ushort Comma        = 0x0033;
	public const ushort Period       = 0x0034;
	public const ushort ForwardSlash = 0x0035;
	
	#endregion
	
	#region Keypad
	
	public const ushort Keypad1            = 0x004F;
	public const ushort Keypad2            = 0x0050;
	public const ushort Keypad3            = 0x0051;
	public const ushort Keypad4            = 0x004B;
	public const ushort Keypad5            = 0x004C;
	public const ushort Keypad6            = 0x004D;
	public const ushort Keypad7            = 0x0047;
	public const ushort Keypad8            = 0x0048;
	public const ushort Keypad9            = 0x0049;
	public const ushort Keypad0            = 0x0052;
	public const ushort KeypadForwardSlash = 0xE035;
	public const ushort KeypadStar         = 0x0037;
	public const ushort KeypadDash         = 0x004A;
	public const ushort KeypadPlus         = 0x004E;
	public const ushort KeypadEnter        = 0xE01C;
	public const ushort KeypadPeriod       = 0x0053;
	
	#endregion
	
	#region Function Keys
	
	public const ushort F1  = 0x003B;
	public const ushort F2  = 0x003C;
	public const ushort F3  = 0x003D;
	public const ushort F4  = 0x003E;
	public const ushort F5  = 0x003F;
	public const ushort F6  = 0x0040;
	public const ushort F7  = 0x0041;
	public const ushort F8  = 0x0042;
	public const ushort F9  = 0x0043;
	public const ushort F10 = 0x0044;
	public const ushort F11 = 0x0057;
	public const ushort F12 = 0x0058;
	public const ushort F13 = 0x0064;
	public const ushort F14 = 0x0065;
	public const ushort F15 = 0x0066;
	public const ushort F16 = 0x0067;
	public const ushort F17 = 0x0068;
	public const ushort F18 = 0x0069;
	public const ushort F19 = 0x006A;
	public const ushort F20 = 0x006B;
	public const ushort F21 = 0x006C;
	public const ushort F22 = 0x006D;
	public const ushort F23 = 0x006E;
	public const ushort F24 = 0x0076;
	
	#endregion
	
	#region Mods
	
	public const ushort LCtrl  = 0x001D;
	public const ushort LShift = 0x002A;
	public const ushort LAlt   = 0x0038;
	public const ushort LWin   = 0xE05B;
	public const ushort RCtrl  = 0xE01D;
	public const ushort RShift = 0x0036;
	public const ushort RAlt   = 0xE038;
	public const ushort RWin   = 0xE05C;
	
	#endregion
	
	#region Consumer
	
	public const ushort BrowserBack      = 0xE06A; // VK_BROWSER_BACK        0xA6
	public const ushort BrowserForward   = 0xE069; // VK_BROWSER_FORWARD     0xA7
	public const ushort BrowserRefresh   = 0xE067; // VK_BROWSER_REFRESH     0xA8
	public const ushort BrowserStop      = 0xE068; // VK_BROWSER_STOP        0xA9
	public const ushort BrowserSearch    = 0xE065; // VK_BROWSER_SEARCH      0xAA
	public const ushort BrowserFavorites = 0xE066; // VK_BROWSER_FAVORITES   0xAB
	public const ushort BrowserHome      = 0xE032; // VK_BROWSER_HOME        0xAC
	public const ushort VolumeMute       = 0xE020; // VK_VOLUME_MUTE         0xAD
	public const ushort VolumeDown       = 0xE02E; // VK_VOLUME_DOWN         0xAE
	public const ushort VolumeUp         = 0xE030; // VK_VOLUME_UP           0xAF
	public const ushort MediaNextTrack   = 0xE019; // VK_MEDIA_NEXT_TRACK    0xB0
	public const ushort MediaPrevTrack   = 0xE010; // VK_MEDIA_PREV_TRACK    0xB1
	public const ushort MediaStop        = 0xE024; // VK_MEDIA_STOP          0xB2
	public const ushort MediaPlayPause   = 0xE022; // VK_MEDIA_PLAY_PAUSE    0xB3
	public const ushort LaunchMail       = 0xE06C; // VK_LAUNCH_MAIL         0xB4
	public const ushort LaunchMedia      = 0xE06D; // VK_LAUNCH_MEDIA_SELECT 0xB5
	public const ushort LaunchApp1       = 0xE06B; // VK_LAUNCH_APP1         0xB6
	public const ushort LaunchApp2       = 0xE021; // VK_LAUNCH_APP2         0xB7
	
	#endregion
	
	#region Others
	
	public const ushort CapsLock   = 0x003A;
	public const ushort ScrollLock = 0x0046;
	public const ushort NumLock    = 0xE045;
	
	public const ushort PrintScreen = 0xE037;
	public const ushort Pause       = 0x0045;
	public const ushort Application = 0xE05D;
	
	#endregion
}
