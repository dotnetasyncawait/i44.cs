using System.Threading;

namespace Lib.Hotkeys;

public class KeyEvent
{
	private readonly CancellationTokenSource _cts = new(); // TODO: dispose?
	
	internal void Set() => _cts.Cancel();
	internal void Dispose() => _cts.Dispose();
	public bool HasOccurred => _cts.Token.IsCancellationRequested;
	public bool Wait(int msTimeout = Timeout.Infinite) => _cts.Token.WaitHandle.WaitOne(msTimeout);
}