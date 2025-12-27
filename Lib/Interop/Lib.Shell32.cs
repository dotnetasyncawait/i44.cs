using System.Runtime.InteropServices;
using static Lib.Interop.Structs;

namespace Lib.Interop;

internal static partial class Shell32
{
	private const string Lib = "Shell32.dll";
	
	[LibraryImport(Lib, EntryPoint = "Shell_NotifyIconW", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static partial bool Shell_NotifyIcon(uint dwMessage, ref NOTIFYICONDATAW lpData);
}