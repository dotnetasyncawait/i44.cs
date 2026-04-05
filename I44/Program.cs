using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Lib;
using Lib.Hotkeys;
using Lib.Hotkeys.Constants;
using Lib.Interop;
using static Lib.Hotkeys.Hotstring;
using static Lib.Hotkeys.Hotkey;

namespace I44;

class Program
{
	[STAThread]
	static void Main()
	{
		Trace.Listeners.Clear();
		Trace.Listeners.Add(new ConsoleTraceListener());
		
		LibApp.AddHotkey((Mod.LW, Key.Num0), () => Async(static _ => LibApp.Exit()));
		
		LibApp.Run();
	}
}

static class Hotkeys
{
	[Hotkey(Mod.LW, Key.Num0)]
	public static Hotkey _Exit() => Async(static _ => LibApp.Exit());
	
	[Hotkey(Key.Num5)]
	static Hotkey OpenTerminal()
	{
		var start = Stopwatch.GetTimestamp();
		CommandRunner.Toggle();
		var elapsed = Stopwatch.GetElapsedTime(start);
		
		Console.WriteLine($"CR.Toggle: {elapsed.TotalMilliseconds} ms");
		return Suppress;
	}
	
	private static int _state;
	
	[Hotkey(Mod.LC, Key.E)] static Hotkey FocusWindow()
	{
		(nint hwnd, string process) = _state switch
		{
			// hardcoded hwnd
			0 => (198856, "Discord.exe"),
			1 => (329698, "opera.exe"),
			2 => (263484, "rider64.exe"),
			3 => (199528, "Code.exe"),
			_ => throw new UnreachableException()
		};
		
		bool succeeded = User32.SetForegroundWindow(hwnd);
		Console.WriteLine($"SetForeground: {succeeded} ({process})");
		
		if (++_state > 3) _state = 0;
		
		return Suppress;
	}
	
	[Hotkey(Mod.LC, Key.Tab)]
	static Hotkey Test()
	{
		var ks = new KeySender(stackalloc Structs.INPUT[5]);
		
		ks.KeyDown(Key.LShift).TapKey(Key.A).ModsUp(Mod.LCS).Send();
		Thread.Sleep(800);
		ks.TapKey(Key.Enter).KeyDown(Key.LCtrl).Send();
		
		return Suppress;
	}
	
	// [Hotkey(Mod.LC, Key.Home)] static Hotkey PrevTab() => (Mod.LC, Key.PageUp);
	// [Hotkey(Mod.LC, Key.End)] static Hotkey NextTab() => (Mod.LC, Key.PageDown);
	
	// [Hotkey(Mod.LS, Key.Up)] static Hotkey ScrollUp()
	// {
	// 	MoveCursorToCenter();
	// 	return Key.WheelUpX2;
	// }
	//
	// [Hotkey(Mod.LS, Key.Down)] static Hotkey ScrollDown()
	// {
	// 	MoveCursorToCenter();
	// 	return Key.WheelDownX2;
	// }
	//
	// private static void MoveCursorToCenter()
	// {
	// 	Interop.GetWindowRect(Interop.GetForegroundWindow(), out var rect);
	// 	Interop.SetCursorPos(rect.left + (rect.right - rect.left) / 2, rect.top  + (rect.bottom - rect.top) / 2);
	// }
	//
	// [Hotkey(Mod.LC, Key.Left)] static Hotkey ScrollLeft() => Key.WheelLeftX16;
	// [Hotkey(Mod.LC, Key.Right)] static Hotkey ScrollRight() => Key.WheelRightX16;
	//
	// [Hotkey(Mod.LS | Mod.RS, Key.LBrace)] static Hotkey _7() => "«";
	// [Hotkey(Mod.LS | Mod.RS, Key.RBrace)] static Hotkey _8() => "»";
	//
	// [Hotkey(Mod.LS, Key.Num8)] static Hotkey _9() => "->";
	//
	// [Hotkey(Key.F21)]
	// static Hotkey DragWindow() => Async(static keyUp =>
	// {
	// 	// TODO: check if the window is maximized
	// 	// TODO: activate target window
	// 	
	// 	Interop.GetCursorPos(out var point);
	// 	var prevMouseX = point.x; var prevMouseY = point.y;
	// 	
	// 	var hwnd = Interop.WindowFromPoint(point);
	// 	Interop.GetWindowRect(hwnd, out var rect);
	// 	var winX = rect.left;
	// 	var winY = rect.top;
	// 	var w = rect.right - rect.left;
	// 	var h = rect.bottom - rect.top;
	// 	
	// 	do
	// 	{
	// 		Interop.GetCursorPos(out point);
	// 		var mouseX = point.x; var mouseY = point.y;
	// 	
	// 		winX += mouseX - prevMouseX;
	// 		winY += mouseY - prevMouseY;
	// 		
	// 		Interop.MoveWindow(hwnd, winX, winY, w, h, true);
	// 		
	// 		prevMouseX = mouseX;
	// 		prevMouseY = mouseY;
	// 		
	// 	} while (!keyUp.HasOccurred);
	// 	
	// 	Console.WriteLine("done");
	// });
	//
	
	/*
		
	*/
}

static class Hotstrings
{
	extension(Process)
	{
		internal static Process? StartShell(string fileName)
			=> Process.Start(new ProcessStartInfo(fileName) { UseShellExecute = true });
	}
	
	[Hotstring(":gx")] static Hotstring _14()
	{
		ThreadPool.QueueUserWorkItem(static _ => Process.StartShell("https://www.youtube.com"));
		return Erase;
	}
	
	[Hotstring("btw")]   static Hotstring _13() => Text("by the way", omitEndChar: false);
	[Hotstring(":test")]  static Hotstring _1() => Text("test");
	[Hotstring(":Test")]  static Hotstring _2() => Text("TEST");
	[Hotstring(":clip")]  static Hotstring _3() => Clipb("TEST");
	[Hotstring(":skip")]  static Hotstring _4() => Skip;
	[Hotstring(":erase")] static Hotstring _5() => Erase;
	
	[Hotstring(":gt")]  static Hotstring _6() => Text(DateTime.Now.ToString("hh:mm:ss tt"));
	[Hotstring(":gd")]  static Hotstring _7() => Text(DateTime.Now.ToString("dd-MMM-yy"));
	[Hotstring(":gdt")] static Hotstring _8() => Text(DateTime.Now.ToString("dd-MMM-yy hh:mm:ss tt"));
	
	[Hotstring("<tag>foo")] static Hotstring _9() => Text("</tag>", deleteTyped: false);
	
	[Hotstring(":guid")] static Hotstring _10() => Text(Guid.NewGuid().ToString());
	[Hotstring(":Guid")] static Hotstring _11() => Text(Guid.NewGuid().ToString().ToUpper());
	
	
	
	// [Hotstring(":yt")] static Hotstring _1() => val switch
	// {
	// 	1 => Text("Hello, World!"),
	// 	2 => Clipb("Hello, World!"),
	// 	3 => "**[]()**{Left 5}",
	// 	4 => Skip,
	// 	5 => Erase,
	// 	_ => throw new NotImplementedException()
	// };

}

static partial class Interop
{
	// ReSharper disable InconsistentNaming
	
	// [LibraryImport("Test")]
	// internal static partial void Test(NOTIFYICONDATAW nid);
	
	[LibraryImport("User32")]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static partial bool GetCursorPos(out POINT lpPoint);
	
	[LibraryImport("User32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static partial bool SetCursorPos(int X, int Y);
	
	[LibraryImport("User32")]
	internal static partial nint WindowFromPoint(POINT point);
	
	[LibraryImport("User32")]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static partial bool GetWindowRect(nint hWnd, out RECT lpRect);
	
	[LibraryImport("User32")]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static partial bool MoveWindow(
		nint hWnd, int x, int y, int nWidth, int nHeight, [MarshalAs(UnmanagedType.Bool)] bool repaint);
	
	[LibraryImport("User32.dll")]
	internal static partial nint GetForegroundWindow();
	
	[StructLayout(LayoutKind.Sequential)]
	internal struct POINT
	{
		internal int x;
		internal int y;
	}

	[StructLayout(LayoutKind.Sequential)]
	internal struct RECT
	{
		internal int left;
		internal int top;
		internal int right;
		internal int bottom;
	}
}


