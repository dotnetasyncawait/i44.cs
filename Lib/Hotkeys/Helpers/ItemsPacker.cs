using System;
using Lib.Hotkeys.Constants;
using static Lib.Interop.Constants;

namespace Lib.Hotkeys.Helpers;

internal readonly record struct InputItem(ushort Key, ushort Flags);

internal ref struct ItemsPacker(Span<InputItem> items)
{
	private readonly Span<InputItem> _items = items;
	private int _index = 0;
	
	internal ItemsPacker ModsDown(byte modBits) => PackMods(modBits, true);
	internal ItemsPacker ModsUp(byte modBits)   => PackMods(modBits, false);
	
	internal ItemsPacker KeyDown(ushort sc) => PackKey(sc, true);
	internal ItemsPacker KeyUp(ushort sc)   => PackKey(sc, false);
	
	internal Span<InputItem> GetItems() => _items[.._index];
	
	internal ItemsPacker PackMods(byte modBits, bool down)
	{
		if (modBits == 0) return this;
		var flags = (ushort)(KEYEVENTF_SCANCODE | (down ? 0 : KEYEVENTF_KEYUP));
		
		if ((modBits & Mod.LC) != 0) _items[_index++] = new InputItem(Key.LCtrl,  flags);
		if ((modBits & Mod.LS) != 0) _items[_index++] = new InputItem(Key.LShift, flags);
		if ((modBits & Mod.LA) != 0) _items[_index++] = new InputItem(Key.LAlt,   flags);
		if ((modBits & Mod.LW) != 0) _items[_index++] = new InputItem(Key.LWin,   (ushort)(flags | KEYEVENTF_EXTENDEDKEY));
		if ((modBits & Mod.RC) != 0) _items[_index++] = new InputItem(Key.RCtrl,  (ushort)(flags | KEYEVENTF_EXTENDEDKEY));
		if ((modBits & Mod.RS) != 0) _items[_index++] = new InputItem(Key.RShift, flags);
		if ((modBits & Mod.RA) != 0) _items[_index++] = new InputItem(Key.RAlt,   (ushort)(flags | KEYEVENTF_EXTENDEDKEY));
		if ((modBits & Mod.RW) != 0) _items[_index++] = new InputItem(Key.RWin,   (ushort)(flags | KEYEVENTF_EXTENDEDKEY));
		
		return this;
	}
	
	private ItemsPacker PackKey(ushort sc, bool state)
	{
		var flags = KEYEVENTF_SCANCODE | (sc >> 8 != 0 ? KEYEVENTF_EXTENDEDKEY : 0) | (state ? 0 : KEYEVENTF_KEYUP);
		_items[_index++] = new InputItem(sc, (ushort)flags);
		return this;
	}
}
