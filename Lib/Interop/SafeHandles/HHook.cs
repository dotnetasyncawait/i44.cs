using System;
using System.Runtime.InteropServices;

namespace Lib.Interop.SafeHandles;

internal class HHook : SafeHandle
{
	public HHook() : base(IntPtr.Zero, true) { }
	
	public override bool IsInvalid => handle == IntPtr.Zero;
	
	protected override bool ReleaseHandle() => User32.UnhookWindowsHookEx(handle);
}