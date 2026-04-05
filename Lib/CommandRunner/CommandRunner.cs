using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using Lib.Hotkeys;
using Lib.Interop;
using Lib.Shared;

// ReSharper disable once CheckNamespace
namespace Lib;

public class CommandRunner
{
	private static readonly RunnerWindow Runner;
	
	static CommandRunner()
	{
		Runner = new RunnerWindow();
	}
	
	public static void Init()
	{
		Debug.WriteLineEx("Initialized");
	}
	
	public static void Toggle()
	{
		Runner.Dispatcher.Invoke(static () =>
		{
			if (Runner.IsVisible)
			{
				Runner.Hide();
			}
			else
			{
				Runner.Show();
				Runner.Activate();
			}
		});
	}
}

