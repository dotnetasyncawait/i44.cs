using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Lib.Hotkeys.Helpers;

internal static class Extensions
{
	extension(List<HotkeyItem> list) 
	{
		internal bool TryGetByEntryKey(ushort key, out HotkeyItem hotkey)
		{
			if (list.Count == 0) goto NotFound;
			
			foreach (var item in list)
			{
				if (item.Entry.Key != key) continue;
				hotkey = item;
				return true;
			}
			
			NotFound:
			hotkey = default!;
			return false;
		}
		
		internal bool TryPopByEntryKey(ushort key, out HotkeyItem hotkey)
		{
			hotkey = default!;
			
			switch (list.Count)
			{
			case 0: return false;
			case 1:
			{
				var item = list[0];
				if (item.Entry.Key != key) return false;
			
				list.RemoveAt(0);
				hotkey = item;
				return true;
				}
			}

			var span = CollectionsMarshal.AsSpan(list);
			
			for (int i = span.Length-1; i >= 0; i--)
			{
				var item = span[i];
				if (item.Entry.Key != key) continue;
				
				span[i] = span[^1];
				list.RemoveAt(list.Count-1);
				
				hotkey = item;
				return true;
			}
			
			return false;
		}
		
		internal bool TryPopByEntryModBit(byte modBit, out HotkeyItem hotkey)
		{
			hotkey = default!;
			if (list.Count == 0) return false;
			
			switch (list.Count)
			{
			case 0: return false;
			case 1:
			{
				var item = list[0];
				if ((item.Entry.Mods & modBit) == 0) return false;
			
				list.RemoveAt(0);
				hotkey = item;
				return true;
				}
			}

			var span = CollectionsMarshal.AsSpan(list);
			
			for (int i = span.Length-1; i >= 0; i--)
			{
				var item = span[i];
				if ((item.Entry.Mods & modBit) == 0) continue;
				
				span[i] = span[^1];
				list.RemoveAt(list.Count-1);
				
				hotkey = item;
				return true;
			}
			
			return false;
		}
	}
}