using System;
using System.Runtime.InteropServices;
using Lib.Hotkeys.Constants;
using Lib.Interop;
using static Lib.Interop.Structs;
using static Lib.Interop.Constants;
using static Lib.Hotkeys.Constants.Misc;

namespace Lib.Hotkeys.Helpers;

internal readonly record struct InputItem(ushort Key, ushort Flags);

internal ref struct KeySender(Span<InputItem> items)
{
	private readonly Span<InputItem> _items = items;
	private int _index = 0;
	
	internal KeySender ModsDown(byte modBits) => AddMods(modBits, true);
	internal KeySender ModsUp(byte modBits) => AddMods(modBits, false);
	
	internal KeySender KeyDown(ushort sc) => AddKey(sc, true);
	internal KeySender KeyUp(ushort sc) => AddKey(sc, false);
	
	internal KeySender ModsDownMasked(byte mods) => AddModsMasked(mods, true);
	internal KeySender ModsUpMasked(byte mods) => AddModsMasked(mods, false);
	
	internal void Send()
	{
		var items = _items[.._index];
		Span<INPUT> inputs = stackalloc INPUT[items.Length];
		
		for (int i = 0; i < items.Length; i++)
		{
			var item = items[i];
			inputs[i] = INPUT.KeybdInput(item.Key, item.Flags, MAGNUM_CALLNEXT);
		}
		
		_ = User32.SendInput((uint)inputs.Length, ref MemoryMarshal.GetReference(inputs), INPUT.Size);
	}
	
	private KeySender AddMods(byte modBits, bool down)
	{
		var flags = (ushort)(KEYEVENTF_SCANCODE | (down ? 0 : KEYEVENTF_KEYUP));
		
		// Add Control before (when pressing) or after (when releasing) others. This helps in cases when we don't mask mods
		// relying on Control being present in the mod-list, since releasing it first would not mask them.
		if (down)
		{
			if ((modBits & Mod.LC) != 0) _items[_index++] = new InputItem(Key.LCtrl, flags);
			if ((modBits & Mod.RC) != 0) _items[_index++] = new InputItem(Key.RCtrl, (ushort)(flags | KEYEVENTF_EXTENDEDKEY));
		}
		
		if ((modBits & Mod.LS) != 0) _items[_index++] = new InputItem(Key.LShift, flags);
		if ((modBits & Mod.LA) != 0) _items[_index++] = new InputItem(Key.LAlt,   flags);
		if ((modBits & Mod.LW) != 0) _items[_index++] = new InputItem(Key.LWin,   (ushort)(flags | KEYEVENTF_EXTENDEDKEY));
		if ((modBits & Mod.RS) != 0) _items[_index++] = new InputItem(Key.RShift, flags);
		if ((modBits & Mod.RA) != 0) _items[_index++] = new InputItem(Key.RAlt,   (ushort)(flags | KEYEVENTF_EXTENDEDKEY));
		if ((modBits & Mod.RW) != 0) _items[_index++] = new InputItem(Key.RWin,   (ushort)(flags | KEYEVENTF_EXTENDEDKEY));
		
		if (!down)
		{
			if ((modBits & Mod.LC) != 0) _items[_index++] = new InputItem(Key.LCtrl, flags);
			if ((modBits & Mod.RC) != 0) _items[_index++] = new InputItem(Key.RCtrl, (ushort)(flags | KEYEVENTF_EXTENDEDKEY));
		}
		
		return this;
	}
	
	private KeySender AddModsMasked(byte mods, bool down)
	{
		bool toMask = (mods & (Mod.LAW | Mod.RAW)) != 0 && (mods & (Mod.LC | Mod.RC)) == 0;
		
		if (toMask) AddKey(MenuMaskKey, true);
		AddMods(mods, down);
		if (toMask) AddKey(MenuMaskKey, false);
		
		return this;
	}
	
	private KeySender AddKey(ushort sc, bool state)
	{
		var flags = KEYEVENTF_SCANCODE | (sc >> 8 != 0 ? KEYEVENTF_EXTENDEDKEY : 0) | (state ? 0 : KEYEVENTF_KEYUP);
		_items[_index++] = new InputItem(sc, (ushort)flags);
		return this;
	}
}
