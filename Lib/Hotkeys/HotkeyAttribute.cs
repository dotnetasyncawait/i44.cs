using System;
using Lib.Hotkeys.Constants;

namespace Lib.Hotkeys;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class HotkeyAttribute(byte mods, ushort key) : Attribute
{
	public HotkeyAttribute(ushort key) : this(Mod.None, key) { }
	
	internal Entry Entry { get; } = new(mods, key);
}