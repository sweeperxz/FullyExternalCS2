using System.Runtime.InteropServices;
using CS2Cheat.System.Data;
using Point = CS2Cheat.System.Data.Point;

namespace CS2Cheat.Core;

public static class User32
{
    #region constants

    public const int WS_EX_TRANSPARENT = 0x20;
    public const int WS_EX_LAYERED = 0x80000;
    public const int LWA_ALPHA = 0x2;
    public const int GWL_EXSTYLE = -20;

    #endregion

    #region routines

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool ClientToScreen(IntPtr hWnd, out Point lpPoint);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern bool GetClientRect(IntPtr hWnd, out Rect lpRect);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    #endregion
}