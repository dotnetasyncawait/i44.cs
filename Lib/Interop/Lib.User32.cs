using System;
using System.Runtime.InteropServices;
using Lib.Interop.SafeHandles;
using static Lib.Interop.Structs;

namespace Lib.Interop;

internal static partial class User32
{
	private const string Lib = "User32.dll";
	
	[LibraryImport(Lib, SetLastError = true, EntryPoint = "SetWindowsHookExW")]
	internal static unsafe partial HHook SetWindowsHookEx(
		int idHook, delegate* unmanaged<int, UIntPtr, KBDLLHOOKSTRUCT*, IntPtr> lpfn, IntPtr hmod, uint dwThreadId);

	[LibraryImport(Lib, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static partial bool UnhookWindowsHookEx(IntPtr hHook);
	
	[LibraryImport(Lib)]
	internal static unsafe partial IntPtr CallNextHookEx(IntPtr hhk, int nCode, UIntPtr wParam, KBDLLHOOKSTRUCT* lParam);
	
	[LibraryImport(Lib, SetLastError = true, EntryPoint = "GetMessageW")]
	internal static partial int GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);
	
	[LibraryImport(Lib)]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static partial bool TranslateMessage(ref MSG lpMsg);
	
	[LibraryImport(Lib, EntryPoint = "DispatchMessageW")]
	internal static partial IntPtr DispatchMessage(ref MSG lpMsg);
	
	[LibraryImport(Lib, SetLastError = true, EntryPoint = "PostThreadMessageW")]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static partial bool PostThreadMessage(uint ihThread, uint msg, UIntPtr wParam, IntPtr lParam);
	
	[LibraryImport(Lib, SetLastError = true)]
	internal static partial uint SendInput(uint cInputs, ref INPUT pInputs, int cbSize);
	
	[LibraryImport(Lib, EntryPoint = "MapVirtualKeyW")]
	internal static partial uint MapVirtualKey(uint uCode, uint uMapType);
}

