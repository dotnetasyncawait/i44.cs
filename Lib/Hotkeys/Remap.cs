namespace Lib.Hotkeys;

public readonly record struct Remap(byte Mods, ushort Key)
{
	public static implicit operator Remap((byte Mods, ushort Key) remap) => new(remap.Mods, remap.Key);
	public static implicit operator Remap(ushort key) => new(0, key);
}