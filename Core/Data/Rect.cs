using System.Runtime.InteropServices;

namespace CS2Cheat.Core.Data;

[StructLayout(LayoutKind.Sequential)]
public struct Rect
{
    public int Left, Top, Right, Bottom;
}