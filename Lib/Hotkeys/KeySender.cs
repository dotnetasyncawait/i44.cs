using System;
using System.Runtime.InteropServices;
using Lib.Hotkeys.Constants;
using Lib.Interop;
using static Lib.Interop.Structs;
using static Lib.Interop.Constants;
using static Lib.Hotkeys.Constants.Misc;

namespace Lib.Hotkeys;

internal ref struct KeySender(Span<INPUT> inputs)
{
	private readonly Span<INPUT> _inputs = inputs;
	private int _index = 0;
	
	internal KeySender ModsDown(byte modBits, bool mask = false) => AddMods(modBits, true, mask);
	internal KeySender ModsUp(byte modBits, bool mask = false) => AddMods(modBits, false, mask);
	
	internal KeySender KeyDown(ushort sc) => AddKey(sc, true);
	internal KeySender KeyUp(ushort sc) => AddKey(sc, false);
	
	internal void Send()
	{
		if (_index > 0)
		{
			_ = User32.SendInput((uint)_inputs.Length, ref MemoryMarshal.GetReference(_inputs), INPUT.Size);
		}
	}
	
	private KeySender AddMods(byte modBits, bool down, bool mask)
	{
		var flags = (ushort)(KEYEVENTF_SCANCODE | (down ? 0 : KEYEVENTF_KEYUP));
		var flagsEx = (ushort)(flags | KEYEVENTF_EXTENDEDKEY);
		
		if (mask) MaskKeyDown();
		
		// Add Control before (when pressing) or after (when releasing) others. This helps in cases when we don't mask mods
		// relying on Control being present in the mod-list, since releasing it first would not mask them.
		if (down)
		{
			if ((modBits & Mod.LC) != 0) _inputs[_index++] = INPUT.KeybdInput(Key.LCtrl, flags,   MAGNUM_CALLNEXT);
			if ((modBits & Mod.RC) != 0) _inputs[_index++] = INPUT.KeybdInput(Key.RCtrl, flagsEx, MAGNUM_CALLNEXT);
		}
		
		if ((modBits & Mod.LS) != 0) _inputs[_index++] = INPUT.KeybdInput(Key.LShift, flags,   MAGNUM_CALLNEXT);
		if ((modBits & Mod.LA) != 0) _inputs[_index++] = INPUT.KeybdInput(Key.LAlt,   flags,   MAGNUM_CALLNEXT);
		if ((modBits & Mod.LW) != 0) _inputs[_index++] = INPUT.KeybdInput(Key.LWin,   flagsEx, MAGNUM_CALLNEXT);
		if ((modBits & Mod.RS) != 0) _inputs[_index++] = INPUT.KeybdInput(Key.RShift, flags,   MAGNUM_CALLNEXT);
		if ((modBits & Mod.RA) != 0) _inputs[_index++] = INPUT.KeybdInput(Key.RAlt,   flagsEx, MAGNUM_CALLNEXT);
		if ((modBits & Mod.RW) != 0) _inputs[_index++] = INPUT.KeybdInput(Key.RWin,   flagsEx, MAGNUM_CALLNEXT);
		
		if (!down)
		{
			if ((modBits & Mod.LC) != 0) _inputs[_index++] = INPUT.KeybdInput(Key.LCtrl, flags,   MAGNUM_CALLNEXT);
			if ((modBits & Mod.RC) != 0) _inputs[_index++] = INPUT.KeybdInput(Key.RCtrl, flagsEx, MAGNUM_CALLNEXT);
		}
		
		if (mask) MaskKeyUp();
		
		return this;
	}
	
	private KeySender AddKey(ushort key, bool down)
	{
		_inputs[_index++] = Helper.IsMouseKey(key) ? INPUT.MouseKey(key, down) : INPUT.KeybdKey(key, down);
		return this;
	}
	
	private void MaskKeyDown() => _inputs[_index++] = INPUT.KeybdKey(MenuMaskKey, true);
	private void MaskKeyUp() => _inputs[_index++] = INPUT.KeybdKey(MenuMaskKey, false);
}
