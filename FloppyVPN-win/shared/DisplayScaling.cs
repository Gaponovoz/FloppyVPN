using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace FloppyVPN
{
	public static class DisplayScaling
	{
		[DllImport("user32.dll", SetLastError = true)]
		private static extern IntPtr GetDC(IntPtr hWnd);

		[DllImport("gdi32.dll", SetLastError = true)]
		private static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

		private const int LOGPIXELSX = 88;

		public static int GetScalingFactor()
		{
			IntPtr hdc = GetDC(IntPtr.Zero);
			if (hdc == IntPtr.Zero)
			{
				return 100;
			}

			int dpiX = GetDeviceCaps(hdc, LOGPIXELSX);
			return (int)(dpiX / 96.0 * 100);  // 96 is the default DPI, so this calculates the percentage.
		}
	}
}
