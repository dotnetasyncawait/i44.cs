using System.Collections.Generic;
using Lib.Hotkeys.Constants;

namespace Lib.Hotkeys;

internal enum KeyType
{
	Letter,
	Symbol,
	Number,
	Keypad,
	Navigation,
	Function
}

internal readonly record struct KeyInfo(KeyType Type, char Lower = '\0', char Upper = '\0');

internal static class Helper
{
	internal static bool IsMouseKey(ushort key) => (key & 0x0200) != 0;
	internal static bool IsMouseButton(ushort key) => key is Key.LButton or Key.RButton or Key.MButton or Key.XButton1 or Key.XButton2;
	internal static bool IsMouseWheel(ushort key) => (key & 0x02FF) is Key.WheelUp or Key.WheelDown or Key.WheelLeft or Key.WheelRight;
	internal static bool IsExtendedKey(ushort key) => (key & 0xE000) == 0xE000;
	
	internal static bool TryGetKeyInfo(ushort sc, out KeyInfo info) => ScInfo.TryGetValue(sc, out info);
	
	private static readonly Dictionary<ushort, KeyInfo> ScInfo = new()
	{
		{ Key.A, new(KeyType.Letter, 'a', 'A') },
		{ Key.B, new(KeyType.Letter, 'b', 'B') },
		{ Key.C, new(KeyType.Letter, 'c', 'C') },
		{ Key.D, new(KeyType.Letter, 'd', 'D') },
		{ Key.E, new(KeyType.Letter, 'e', 'E') },
		{ Key.F, new(KeyType.Letter, 'f', 'F') },
		{ Key.G, new(KeyType.Letter, 'g', 'G') },
		{ Key.H, new(KeyType.Letter, 'h', 'H') },
		{ Key.I, new(KeyType.Letter, 'i', 'I') },
		{ Key.J, new(KeyType.Letter, 'j', 'J') },
		{ Key.K, new(KeyType.Letter, 'k', 'K') },
		{ Key.L, new(KeyType.Letter, 'l', 'L') },
		{ Key.M, new(KeyType.Letter, 'm', 'M') },
		{ Key.N, new(KeyType.Letter, 'n', 'N') },
		{ Key.O, new(KeyType.Letter, 'o', 'O') },
		{ Key.P, new(KeyType.Letter, 'p', 'P') },
		{ Key.Q, new(KeyType.Letter, 'q', 'Q') },
		{ Key.R, new(KeyType.Letter, 'r', 'R') },
		{ Key.S, new(KeyType.Letter, 's', 'S') },
		{ Key.T, new(KeyType.Letter, 't', 'T') },
		{ Key.U, new(KeyType.Letter, 'u', 'U') },
		{ Key.V, new(KeyType.Letter, 'v', 'V') },
		{ Key.W, new(KeyType.Letter, 'w', 'W') },
		{ Key.X, new(KeyType.Letter, 'x', 'X') },
		{ Key.Y, new(KeyType.Letter, 'y', 'Y') },
		{ Key.Z, new(KeyType.Letter, 'z', 'Z') },
		
		{ Key.Dash,         new(KeyType.Symbol, '-',  '_') },
		{ Key.Equals,       new(KeyType.Symbol, '=',  '+') },
		{ Key.LBrace,       new(KeyType.Symbol, '[',  '{') },
		{ Key.RBrace,       new(KeyType.Symbol, ']',  '}') },
		{ Key.Backslash,    new(KeyType.Symbol, '\\', '|') },
		{ Key.SemiColon,    new(KeyType.Symbol, ';',  ':') },
		{ Key.Apostrophe,   new(KeyType.Symbol, '\'', '"') },
		{ Key.Grave,        new(KeyType.Symbol, '`',  '~') },
		{ Key.Comma,        new(KeyType.Symbol, ',',  '<') },
		{ Key.Period,       new(KeyType.Symbol, '.',  '>') },
		{ Key.ForwardSlash, new(KeyType.Symbol, '/',  '?') },
		
		{ Key.Num1, new(KeyType.Number, '1', '1') },
		{ Key.Num2, new(KeyType.Number, '2', '2') },
		{ Key.Num3, new(KeyType.Number, '3', '3') },
		{ Key.Num4, new(KeyType.Number, '4', '4') },
		{ Key.Num5, new(KeyType.Number, '5', '5') },
		{ Key.Num6, new(KeyType.Number, '6', '6') },
		{ Key.Num7, new(KeyType.Number, '7', '7') },
		{ Key.Num8, new(KeyType.Number, '8', '8') },
		{ Key.Num9, new(KeyType.Number, '9', '9') },
		{ Key.Num0, new(KeyType.Number, '0', '0') },
		
		{ Key.Escape,    new(KeyType.Navigation) },
		{ Key.Enter,     new(KeyType.Navigation) },
		{ Key.Tab,       new(KeyType.Navigation) },
		{ Key.Space,     new(KeyType.Navigation) },
		{ Key.Backspace, new(KeyType.Navigation) },
		{ Key.Delete,    new(KeyType.Navigation) },
		{ Key.Insert,    new(KeyType.Navigation) },
		{ Key.Home,      new(KeyType.Navigation) },
		{ Key.End,       new(KeyType.Navigation) },
		{ Key.PageUp,    new(KeyType.Navigation) },
		{ Key.PageDown,  new(KeyType.Navigation) },
		{ Key.Up,        new(KeyType.Navigation) },
		{ Key.Down,      new(KeyType.Navigation) },
		{ Key.Left,      new(KeyType.Navigation) },
		{ Key.Right,     new(KeyType.Navigation) },
	};
}