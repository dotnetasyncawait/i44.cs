using System;
using System.Diagnostics.CodeAnalysis;

namespace Lib.Hotkeys;

internal class HotkeyHandler
{
	[MemberNotNullWhen(true, nameof(Remap))]   internal bool IsRemap { get; }
	[MemberNotNullWhen(true, nameof(Action))]  internal bool IsAction { get; }
	[MemberNotNullWhen(true, nameof(Unicode))] internal bool IsUnicode { get; }
	
	internal Func<Remap?>? Remap { get; }
	internal Action<KeyEvent>? Action { get; }
	internal Func<string>? Unicode { get; }
	
	internal HotkeyHandler(Func<Remap?> remap) =>
		(IsRemap, Remap, IsAction, Action, IsUnicode, Unicode) = (true, remap, false, null, false, null);
	
	internal HotkeyHandler(Action<KeyEvent> action) =>
		(IsRemap, Remap, IsAction, Action, IsUnicode, Unicode) = (false, null, true, action, false, null);
	
	internal HotkeyHandler(Func<string> unicode) =>
		(IsRemap, Remap, IsAction, Action, IsUnicode, Unicode) = (false, null, false, null, true, unicode);
}
