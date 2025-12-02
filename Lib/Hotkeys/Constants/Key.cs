namespace Lib.Hotkeys.Constants;

public static class Key
{
	public const ushort A = 0x001E;
	public const ushort B = 0x0030;
	public const ushort C = 0x002E;
	public const ushort D = 0x0020;
	
	public const ushort L = 0x0017;
	
	public const ushort Q = 0x0010;
	public const ushort T = 0x0014;
	
	public const ushort W = 0x0011;
	
	public const ushort Enter = 0x001C;
	public const ushort Space = 0x0039;
	
	public const ushort Right = 0xE04D;
	public const ushort Left  = 0xE04B;
	public const ushort Down  = 0xE050;
	public const ushort Up    = 0xE048;
	
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
}
