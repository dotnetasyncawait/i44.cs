using System;
using System.Diagnostics.CodeAnalysis;

namespace Lib.Hotkeys;

internal class HotkeyHandler
{
	[MemberNotNullWhen(true, nameof(Action))]
	[MemberNotNullWhen(false, nameof(Remap))]
	internal bool IsAction { get; }
	
	internal Func<Remap?>? Remap { get; }
	internal Action<bool>? Action { get; }
	
	internal HotkeyHandler(Func<Remap?> remap) => (IsAction, Remap, Action) = (false, remap, null);
	internal HotkeyHandler(Action<bool> action) => (IsAction, Remap, Action) = (true, null, action);
}
