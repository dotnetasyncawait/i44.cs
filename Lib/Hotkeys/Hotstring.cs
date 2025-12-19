namespace Lib.Hotkeys;

public readonly struct Hotstring
{
	internal SendMode Mode { get; }
	internal bool DeleteTyped { get; }
	internal bool OmitEndChar { get; }
	internal bool RestoreClipboard { get; }
	internal string Replacement { get; }

	private Hotstring(
		string replacement, SendMode mode, bool deleteTyped = true, bool omitEndChar = true, bool restoreClipboard = true)
	{
		Replacement = replacement; Mode = mode; DeleteTyped = deleteTyped;
		OmitEndChar = omitEndChar; RestoreClipboard = restoreClipboard;
	}
	
	public static readonly Hotstring Skip = new("", SendMode.Default, false);
	public static readonly Hotstring Erase = new("", SendMode.Default);
	
	public static Hotstring Text(string replacement, bool deleteTyped = true, bool omitEndChar = true)
		=> new(replacement, SendMode.Text, deleteTyped, omitEndChar);
	
	public static Hotstring Clipb(string replacement, bool deleteTyped = true, bool omitEndChar = true, bool restore = true)
		=> new(replacement, SendMode.Clipboard, deleteTyped, omitEndChar, restore);
	
	public static implicit operator Hotstring(string replacement) => new(replacement, SendMode.Default);
	
	internal enum SendMode
	{
		Default,
		Text,
		Clipboard
	}
}
