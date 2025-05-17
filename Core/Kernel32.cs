using System;
using System.Runtime.InteropServices;

namespace CS2Cheat.Core
{
    public abstract class Kernel32
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory(
            IntPtr hProcess,            // Handle to the process
            IntPtr lpBaseAddress,       // Base address to read from
            [Out] IntPtr lpBuffer,      // Buffer that receives the data
            int dwSize,                 // Number of bytes to read
            out int lpNumberOfBytesRead // Number of bytes actually read
        );
    }
}
