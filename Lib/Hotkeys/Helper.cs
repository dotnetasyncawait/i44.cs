using Lib.Hotkeys.Constants;

namespace Lib.Hotkeys;

internal static class Helper
{
	internal static bool IsMouseKey(ushort key) => (key & 0x0200) != 0;
	internal static bool IsMouseButton(ushort key) => key is Key.LButton or Key.RButton or Key.MButton or Key.XButton1 or Key.XButton2;
	internal static bool IsMouseWheel(ushort key) => key is Key.WheelUp or Key.WheelDown or Key.WheelLeft or Key.WheelRight;
	internal static bool IsExtendedKey(ushort key) => (key & 0xE000) == 0xE000;
}