using System;
using Lib.Hotkeys.Constants;
using static Lib.Interop.Constants;

namespace Lib.Hotkeys.Helpers;

internal readonly record struct InputItem(ushort Key, ushort Flags);

internal ref struct ItemsPacker(Span<InputItem> items)
{
	private readonly Span<InputItem> _items = items;
	private int _index = 0;
	
	internal ItemsPacker ModsDown(byte modBits) => PackModBits(modBits, true);
	internal ItemsPacker ModsUp(byte modBits) => PackModBits(modBits, false);
	
	internal ItemsPacker KeyDown(ushort key) => PackKey(key, true);
	internal ItemsPacker KeyUp(ushort key) => PackKey(key, false);
	
	internal Span<InputItem> GetItems() => _items[.._index];
	
	private ItemsPacker PackModBits(byte modBits, bool state)
	{
		if (modBits == 0) return this;
		var flags = (ushort)(KEYEVENTF_SCANCODE | (state ? 0 : KEYEVENTF_KEYUP));
		
		if ((modBits & Mod.LCtrl)  != 0) _items[_index++] = new InputItem(Key.LCtrl,  flags);
		if ((modBits & Mod.LShift) != 0) _items[_index++] = new InputItem(Key.LShift, flags);
		if ((modBits & Mod.LAlt)   != 0) _items[_index++] = new InputItem(Key.LAlt,   flags);
		if ((modBits & Mod.LWin)   != 0) _items[_index++] = new InputItem(Key.LWin,   (ushort)(flags | KEYEVENTF_EXTENDEDKEY));
		if ((modBits & Mod.RCtrl)  != 0) _items[_index++] = new InputItem(Key.RCtrl,  (ushort)(flags | KEYEVENTF_EXTENDEDKEY));
		if ((modBits & Mod.RShift) != 0) _items[_index++] = new InputItem(Key.RShift, flags);
		if ((modBits & Mod.RAlt)   != 0) _items[_index++] = new InputItem(Key.RAlt,   (ushort)(flags | KEYEVENTF_EXTENDEDKEY));
		if ((modBits & Mod.RWin)   != 0) _items[_index++] = new InputItem(Key.RWin,   (ushort)(flags | KEYEVENTF_EXTENDEDKEY));
		
		return this;
	}
	
	private ItemsPacker PackKey(ushort key, bool state)
	{
		var flags = KEYEVENTF_SCANCODE | (key >> 8 != 0 ? KEYEVENTF_EXTENDEDKEY : 0) | (state ? 0 : KEYEVENTF_KEYUP);
		_items[_index++] = new InputItem(key, (ushort)flags);
		return this;
	}
}
