using System.Diagnostics;
using CS2Cheat.Core;
using CS2Cheat.Utils;

namespace CS2Cheat.Data.Game;

public class GameProcess : ThreadedServiceBase
{
    #region constants

    private const string NameProcess = "cs2";

    private const string NameModule = "client.dll";

    private const string NameWindow = "Counter-Strike 2";

    #endregion

    #region properties

    protected override string ThreadName => nameof(GameProcess);

    protected override TimeSpan ThreadFrameSleep { get; set; } = new(0, 0, 0, 0, 500);

    public System.Diagnostics.Process? Process { get; private set; }

    public Module? ModuleClient { get; private set; }

    public IntPtr WindowHwnd { get; private set; }

    public Rectangle WindowRectangleClient { get; private set; }

    private bool WindowActive { get; set; }

    public bool IsValid => WindowHwnd != IntPtr.Zero &&
                           Process != null &&
                           ModuleClient != null &&
                           WindowRectangleClient.Width > 0;

    public bool IsGameForeground => WindowActive;

    #endregion

    #region routines

    public override void Dispose()
    {
        InvalidateWindow();
        InvalidateModules();
        base.Dispose();
    }


    protected override async void FrameAction()
    {
        if (!EnsureProcessAndModules()) InvalidateModules();

        EnsureWindow();

        await Task.Delay(ThreadFrameSleep);
    }


    private void InvalidateModules()
    {
        ModuleClient?.Dispose();
        ModuleClient = default;

        Process?.Dispose();
        Process = default;
    }

    private void InvalidateWindow()
    {
        WindowHwnd = IntPtr.Zero;
        WindowRectangleClient = Rectangle.Empty;
        WindowActive = false;
    }

    private bool EnsureProcessAndModules()
    {
        Process ??= System.Diagnostics.Process.GetProcessesByName(NameProcess).FirstOrDefault()!;
        if (Process == null || Process.HasExited) return false;

        if (ModuleClient == null && Process != null)
        {
            var processModule = Process.Modules
                .OfType<ProcessModule>()
                .FirstOrDefault(m => m.ModuleName.Equals(NameModule, StringComparison.OrdinalIgnoreCase));
            if (processModule != null)
                ModuleClient = new Module(Process, processModule);
        }

        return ModuleClient != null;
    }


    private void EnsureWindow()
    {
        var hwnd = User32.FindWindow(null!, NameWindow);
        if (hwnd == IntPtr.Zero)
        {
            InvalidateWindow();
            return;
        }

        WindowHwnd = hwnd;
        var rect = Utility.GetClientRectangle(hwnd);
        if (rect.Width > 0 && rect.Height > 0)
        {
            WindowRectangleClient = rect;
        }

        WindowActive = hwnd == User32.GetForegroundWindow();
    }

    #endregion
}