using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Interop;
using Lib.Hotkeys;
using Lib.Shared;

namespace Lib;

public static class LibApp
{
	private static readonly Application App;
	private static readonly MainWindow MainWindow;
	private static readonly List<Action> OnExitCallbacks = [];
	
	public static nint Hwnd => MainWindow.Hwnd;

	static LibApp()
	{
		App = new Application();
		
		MainWindow = new MainWindow();
		
		App.MainWindow = MainWindow;
		App.ShutdownMode = ShutdownMode.OnMainWindowClose;
		App.Exit += ExitHandler;
	}

	public static void Run()
	{
		Debug.WriteLineEx("Starting...");
		
		CommandRunner.Init();
		InputHook.Start();
		
		App.Run();
		
		Debug.WriteLineEx("Exiting...");
	}
	
	public static void Exit() => App.Dispatcher.Invoke(static () => App.Shutdown());
	
	public static void OnMessage(int messageId, HwndSourceHook callback) => MainWindow.OnMessage(messageId, callback);
	
	public static void RemoveOnMessage(int messageId, HwndSourceHook callback) => MainWindow.RemoveOnMessage(messageId, callback);
	
	public static void OnExit(Action callback) => OnExitCallbacks.Add(callback);
	
	private static void ExitHandler(object _, ExitEventArgs e)
	{
		Debug.WriteLineEx($"Shutting down with exit code: {e.ApplicationExitCode}");
		
		InputHook.ExitWait();
		
		foreach (var callback in OnExitCallbacks)
		{
			callback();
		}
		
		// TODO: clear the fields?
	}
}

