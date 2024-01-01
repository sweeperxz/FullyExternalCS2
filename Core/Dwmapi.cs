using System.Runtime.InteropServices;
using Margins = CS2Cheat.System.Data.Margins;

namespace CS2Cheat.System;

public static class Dwmapi
{
    [DllImport("dwmapi.dll", SetLastError = true)]
    public static extern void DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margins pMargins);
}