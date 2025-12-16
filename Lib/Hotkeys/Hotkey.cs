using System;
using System.Diagnostics.CodeAnalysis;
using Lib.Hotkeys.Constants;

namespace Lib.Hotkeys;

internal readonly record struct Hotkey
{
	internal bool IsRemap { get; }
	internal bool IsUnicode { get; }
	[MemberNotNullWhen(true, nameof(Action))] internal bool IsAction { get; }
	
	internal Remap Remap { get; }
	internal string? Unicode { get; }
	internal Action<KeyEvent>? Action { get; }
	
	public static Hotkey Default = new((Remap)default);
	public static Hotkey Suppress = new((string?)null);
	
	internal Hotkey(Remap remap) => 
		(IsRemap, Remap, IsUnicode, Unicode, IsAction, Action) = (true, remap, false, null, false, null);
	
	internal Hotkey(string? unicode) =>
		(IsRemap, Remap, IsUnicode, Unicode, IsAction, Action) = (false, default, true, unicode, false, null);
	
	internal Hotkey(Action<KeyEvent> action) =>
		(IsRemap, Remap, IsUnicode, Unicode, IsAction, Action) = (false, default, false, null, true, action);
	
	public static Hotkey Async(Action<KeyEvent> action) => new(action);
	
	public static implicit operator Hotkey((byte Mods, ushort Key) r) => new(new Remap(r.Mods, r.Key));
	public static implicit operator Hotkey(ushort key) => new(new Remap(Mod.None, key));
	public static implicit operator Hotkey(string unicode) => new(unicode);
}
