using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using Lib.Shared;

// ReSharper disable once CheckNamespace
namespace Lib;

internal class RunnerWindow : Window
{
	private TextBox _text;
	private StackPanel _panel;
	
	internal nint Hwnd { get; }
	
	internal RunnerWindow()
	{
		InitializeComponent();
		
		Hwnd = new WindowInteropHelper(this).EnsureHandle();
		
		// ReSharper disable InconsistentNaming
		const int WS_EX_TOOLWINDOW = 0x00000080;
		const int GWL_EXSTYLE = -20;
    _ = MyInterop.SetWindowLong(Hwnd, GWL_EXSTYLE, MyInterop.GetWindowLong(Hwnd, GWL_EXSTYLE) | WS_EX_TOOLWINDOW);
	}
	
	[MemberNotNull(nameof(_text), nameof(_panel))]
	private void InitializeComponent()
	{
		_text = new TextBox
		{
			Margin = new Thickness(0),
			Background = new SolidColorBrush(Color.FromRgb(0x17, 0x17, 0x17)),
			FontFamily = new FontFamily("JetBrains Mono Regular"),
			FontSize = 23.5,
			Foreground = new SolidColorBrush(Color.FromRgb(0xBD, 0xBD, 0xBD)),
			Height = 35,
			TextAlignment = TextAlignment.Center,
			Padding = new Thickness(0),
			Opacity = 0.95
		};
		
		_panel = new StackPanel { Children = { _text }, Focusable = true };
		Content = _panel;
		
		WindowStyle = WindowStyle.None;
		AllowsTransparency = true;
		Opacity = 240;
		Background = Brushes.Transparent;
		
		ShowInTaskbar = false; // -WS_EX_APPWINDOW
		Topmost = true;
		
		Left = 598;
		Top = 261 + _text.Height;
		Width = 900;
		Height = 60;
		
		Deactivated += (_, _) =>
		{
			Debug.WriteLineEx("deactivated");
			Hide();
		};
		
		Activated += (_, _) =>
		{
			Debug.WriteLineEx("activated");
			Keyboard.Focus(_text);
		};
	}
}

static partial class MyInterop
{
  [LibraryImport("user32", EntryPoint = "GetWindowLongW", SetLastError = true)]
  public static partial int GetWindowLong(nint hwnd, int nIndex);
  
  [LibraryImport("user32", EntryPoint = "SetWindowLongW", SetLastError = true)]
  public static partial int SetWindowLong(nint hwnd, int nIndex, int dwNewLong);
  
  [LibraryImport("user32", SetLastError = true)]
  [return: MarshalAs(UnmanagedType.Bool)]
  public static partial bool SetLayeredWindowAttributes(nint hwnd, uint colorref, byte bAlpha, uint dwFlags);
}