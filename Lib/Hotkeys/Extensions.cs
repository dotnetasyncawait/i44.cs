using System;
using System.Diagnostics;
using Lib.Hotkeys.Constants;
using static Lib.Hotkeys.Constants.Misc;
using static Lib.Interop.Structs;
using static Lib.Interop.Constants;

namespace Lib.Hotkeys;

internal static class Extensions
{
	extension(INPUT)
	{
		internal static INPUT MouseKey(ushort key, bool down)
		{
			(uint flags, uint data) = key switch
			{
				Key.LButton  => (MOUSEEVENTF_LEFTDOWN, 0u),
				Key.RButton  => (MOUSEEVENTF_RIGHTDOWN, 0u),
				Key.MButton  => (MOUSEEVENTF_MIDDLEDOWN, 0u),
				Key.XButton1 => (MOUSEEVENTF_XDOWN, XBUTTON1),
				Key.XButton2 => (MOUSEEVENTF_XDOWN, XBUTTON2),
				
				Key.WheelUp    => (MOUSEEVENTF_WHEEL,  (uint)WHEEL_DELTA),
				Key.WheelDown  => (MOUSEEVENTF_WHEEL,  unchecked((uint)-WHEEL_DELTA)),
				Key.WheelLeft  => (MOUSEEVENTF_HWHEEL, unchecked((uint)-WHEEL_DELTA)),
				Key.WheelRight => (MOUSEEVENTF_HWHEEL, (uint)WHEEL_DELTA),
				
				_ => throw new Exception($"Invalid mouse key 0x{key:X}")
			};
			
			if (!down)
			{
				Debug.Assert(!Helper.IsMouseWheel(key), "Mouse wheels do not have 'down' state");
				flags <<= 1; // MOUSEEVENTF_<key>UP
			}
			
			return INPUT.MouseInput(data, flags, MAGNUM_CALLNEXT);
		}

		internal static INPUT KeybdKey(ushort key, bool down)
		{
			var flags = KEYEVENTF_SCANCODE | (Helper.IsExtendedKey(key) ? KEYEVENTF_EXTENDEDKEY : 0) | (down ? 0 : KEYEVENTF_KEYUP);
			return INPUT.KeybdInput(key, (uint)flags, MAGNUM_CALLNEXT);
		}
	}
}