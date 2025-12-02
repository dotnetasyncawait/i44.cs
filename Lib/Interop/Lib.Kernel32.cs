using System.Runtime.InteropServices;

namespace Lib.Interop;

internal static partial class Kernel32
{
	private const string Lib = "Kernel32.dll";
	
	[LibraryImport(Lib)]
	internal static partial uint GetCurrentThreadId();
}