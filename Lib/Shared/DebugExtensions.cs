using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace Lib.Shared;

internal static class DebugExtensions
{
	extension(Debug)
	{
		[Conditional("DEBUG")]
		internal static void WriteLineEx(string message, [CallerFilePath] string? callerPath = null)
			=> Debug.WriteLine($"[{Path.GetFileNameWithoutExtension(callerPath)}] {message}");
	}
}