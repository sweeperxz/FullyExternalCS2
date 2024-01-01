using System.Diagnostics;
using System.Runtime.InteropServices;
using CS2Cheat.System;
using static System.Diagnostics.Process;


namespace CS2Cheat.Utils;

public static class Utility
{
    private const double _PI_Over_180 = Math.PI / 180.0;
    private const double _180_Over_PI = 180.0 / Math.PI;

    public static double DegreeToRadian(this double degree)
    {
        return degree * _PI_Over_180;
    }

    public static double RadianToDegree(this double radian)
    {
        return radian * _180_Over_PI;
    }

    public static float DegreeToRadian(this float degree)
    {
        return (float)(degree * _PI_Over_180);
    }

    public static float RadianToDegree(this float radian)
    {
        return (float)(radian * _180_Over_PI);
    }


    public static Rectangle GetClientRectangle(IntPtr handle)
    {
        return User32.ClientToScreen(handle, out var point) && User32.GetClientRect(handle, out var rect)
            ? new Rectangle(point.X, point.Y, rect.Right - rect.Left, rect.Bottom - rect.Top)
            : default;
    }


    public static Module GetModule(this global::System.Diagnostics.Process process, string moduleName)
    {
        var processModule = process.GetProcessModule(moduleName);
        return processModule is null || processModule.BaseAddress == IntPtr.Zero
            ? default
            : new Module(process, processModule);
    }


    public static ProcessModule GetProcessModule(this global::System.Diagnostics.Process process,
        string moduleName)
    {
        return process?.Modules.OfType<ProcessModule>()
            .FirstOrDefault(a => string.Equals(a.ModuleName.ToLower(), moduleName.ToLower()));
    }


    public static bool IsRunning(this global::System.Diagnostics.Process process)
    {
        try
        {
            GetProcessById(process.Id);
        }
        catch (InvalidOperationException)
        {
            return false;
        }
        catch (ArgumentException)
        {
            return false;
        }

        return true;
    }


    #region memory

    public static T Read<T>(this global::System.Diagnostics.Process process, IntPtr lpBaseAddress)
        where T : unmanaged
    {
        return Read<T>(process.Handle, lpBaseAddress);
    }


    public static T Read<T>(this Module module, int offset)
        where T : unmanaged
    {
        return Read<T>(module.Process.Handle, module.ProcessModule.BaseAddress + offset);
    }


    public static T Read<T>(IntPtr hProcess, IntPtr lpBaseAddress)
        where T : unmanaged
    {
        var size = Marshal.SizeOf<T>();
        var buffer = (object)default(T);
        Kernel32.ReadProcessMemory(hProcess, lpBaseAddress, buffer, size, out var lpNumberOfBytesRead);
        return lpNumberOfBytesRead == size ? (T)buffer : default;
    }

    #endregion


    private static bool IsInfinityOrNaN(this float value)
    {
        return float.IsNaN(value) || float.IsInfinity(value);
    }
}