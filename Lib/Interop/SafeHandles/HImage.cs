using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using static Lib.Interop.Constants;

namespace Lib.Interop.SafeHandles;

internal class HImage : SafeHandle
{
	private readonly uint _type;
	
	internal HImage(nint hImage, uint type) : base(nint.Zero, true)
	{
		Debug.Assert(type is IMAGE_BITMAP or IMAGE_ICON or IMAGE_CURSOR);
		
		handle = hImage; _type = type;
	}

	public override bool IsInvalid => handle == nint.Zero;
	
	protected override bool ReleaseHandle()
	{
		return _type switch
		{
			IMAGE_BITMAP => throw new NotImplementedException(),
			IMAGE_ICON   => User32.DestroyIcon(handle),
			IMAGE_CURSOR => throw new NotImplementedException(),
			_ => throw new Exception("Invalid image type")
		};
	}
}
