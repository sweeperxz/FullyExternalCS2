using System.Runtime.InteropServices;

namespace CS2Cheat.Core;

public abstract class Kernel32
{
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress,
        [Out] IntPtr lpBuffer, int dwSize, out int lpNumberOfBytesRead);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    public static extern IntPtr GetModuleHandle(string lpModuleName);
}