using Process.NET.Native;
using Process.NET.Native.Types;
using User32 = CS2Cheat.Core.User32;

namespace CS2Cheat.Utils;

public class GlobalHook :
    IDisposable
{
    public GlobalHook(HookType hookType, HookProc hookProc)
    {
        HookType = hookType;
        HookProc = hookProc;
        HookHandle = Hook(HookType, HookProc);
    }

    private HookType HookType { get; }

    private HookProc HookProc { get; set; }

    public IntPtr HookHandle { get; private set; }

    public void Dispose()
    {
        ReleaseUnmanagedResources();

        GC.SuppressFinalize(this);
    }

    ~GlobalHook()
    {
        ReleaseUnmanagedResources();
    }

    private void ReleaseUnmanagedResources()
    {
        UnHook(HookHandle);
        HookHandle = default;
        HookProc = default;
    }


    private static IntPtr Hook(HookType hookType, HookProc hookProc)
    {
        using var currentProcess = System.Diagnostics.Process.GetCurrentProcess();
        using var curModule = currentProcess.MainModule;
        if (curModule is null) throw new ArgumentNullException(nameof(curModule));

        var hHook = User32.SetWindowsHookEx((int)hookType, hookProc,
            Kernel32.GetModuleHandle(curModule.ModuleName), 0);
        if (hHook == IntPtr.Zero) throw new ArgumentException("Hook failed.");

        return hHook;
    }

    private static void UnHook(IntPtr hHook)
    {
        if (!User32.UnhookWindowsHookEx(hHook)) throw new ArgumentException("UnHook failed.");
    }
}