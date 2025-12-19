using System;

namespace Lib.Hotkeys;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public class HotstringAttribute(string entry) : Attribute
{
	internal string Entry { get; } = entry;
}