namespace Lib.Hotkeys.Constants;

// ReSharper disable InconsistentNaming
public static class Mod
{
	public const byte LCtrl  = 0x01; // 00000001
	public const byte LShift = 0x02; // 00000010
	public const byte LAlt   = 0x04; // 00000100
	public const byte LWin   = 0x08; // 00001000
	public const byte RCtrl  = 0x10; // 00010000
	public const byte RShift = 0x20; // 00100000
	public const byte RAlt   = 0x40; // 01000000
	public const byte RWin   = 0x80; // 10000000
	
	public const byte None = 0;
	
	public const byte LC = LCtrl;
	public const byte LS = LShift;
	public const byte LA = LAlt;
	public const byte LW = LWin;
	public const byte RC = RCtrl;
	public const byte RS = RShift;
	public const byte RA = RAlt;
	public const byte RW = RWin;
	
	public const byte LCS = LC | LS;
	public const byte LCA = LC | LA;
	public const byte LCW = LC | LW;
	public const byte LSA = LS | LA;
	public const byte LSW = LS | LW;
	public const byte LAW = LA | LW;
	public const byte RCS = RC | RS;
	public const byte RCA = RC | RA;
	public const byte RCW = RC | RW;
	public const byte RSA = RS | RA;
	public const byte RSW = RS | RW;
	public const byte RAW = RA | RW;
	
	public const byte LCSA = LCS | LA;
	public const byte LCSW = LCS | LW;
	public const byte LCAW = LCA | LW;
	public const byte LSAW = LSA | LW;
	public const byte RCSA = RCS | RA;
	public const byte RCSW = RCS | RW;
	public const byte RCAW = RCA | RW;
	public const byte RSAW = RSA | RW;
	
	public const byte LCSAW = LCSA | LW;
	public const byte RCSAW = RCSA | RW;
}