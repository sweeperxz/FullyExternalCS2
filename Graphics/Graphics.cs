using System.Windows.Threading;
using CS2Cheat.Data;
using CS2Cheat.Features;
using CS2Cheat.Gfx;
using CS2Cheat.Utils;
using Yato.DirectXOverlay;
using static System.Windows.Application;
using Direct2DBrush = Yato.DirectXOverlay.Direct2DBrush;

namespace CS2Cheat.Graphics;

public class Graphics :
    ThreadedServiceBase
{
    protected override string ThreadName => nameof(Graphics);


    internal WindowOverlay WindowOverlay { get; set; }


    private GameProcess GameProcess { get; set; }


    internal GameData GameData { get; private set; }

    private OverlayWindow OverlayWindow { get; set; }

    internal Direct2DRenderer D2d { get; }

    private Direct2DBrush ClearBrush { get; }
    private Direct2DFont Font { get; }

    private Direct2DBrush BlackBrush { get; }
    private Direct2DBrush GreenBrush { get; }
    public Direct2DBrush RedBrush { get; }

    private Direct2DRendererOptions Direct2DRendererOptions
    {
        get =>
            new()
            {
                AntiAliasing = true,
                Hwnd = IntPtr.Zero,
                MeasureFps = true,
                VSync = true
            };
        set => Direct2DRendererOptions = value;
    }

    private OverlayManager OverlayManager { get; }


    public Graphics(WindowOverlay windowOverlay, GameProcess gameProcess, GameData gameData)
    {
        GameProcess = gameProcess;
        D2d = new Direct2DRenderer(GameProcess.Process.MainWindowHandle);

        OverlayManager = new OverlayManager(GameProcess.Process.MainWindowHandle, Direct2DRendererOptions);
        OverlayWindow = OverlayManager.Window;
        D2d = OverlayManager.Graphics;
        WindowOverlay = windowOverlay;
        GameData = gameData;
        Font = D2d.CreateFont("Tahoma", 14);
        BlackBrush = D2d.CreateBrush(0, 0, 0);
        GreenBrush = D2d.CreateBrush(0, 255, 0);
        ClearBrush = D2d.CreateBrush(0xF5, 0xF5, 0xF5, 0);
        RedBrush = D2d.CreateBrush(255, 0, 0);
    }

    public override void Dispose()
    {
        base.Dispose();
        GameData = default;
        GameProcess = default;
        WindowOverlay = default;
        OverlayWindow = default;

        OverlayWindow.Dispose();
        D2d.Dispose();
        ClearBrush.Brush.Dispose();
        Font.Font.Dispose();
        BlackBrush.Brush.Dispose();
        RedBrush.Brush.Dispose();
    }

    protected override void FrameAction()
    {
        if (!GameProcess.IsValid) return;
        Current.Dispatcher.Invoke(Render, DispatcherPriority.Normal);
    }


    private void Render()
    {
        D2d.BeginScene();
        D2d.ClearScene(ClearBrush);
        DrawFps();
        DrawWindowBorder();
        EspAimCrosshair.Draw(this);
        D2d.EndScene();
    }


    private void DrawFps()
    {
        D2d.DrawTextWithBackground($"{D2d.FPS}", 15, 15, Font, BlackBrush, GreenBrush);
    }


    private void DrawWindowBorder()
    {
        D2d.DrawRectangle(0, 0, WindowOverlay.Window.Width, WindowOverlay.Window.Height, 2.0f,
            new Direct2DColor(255, 0, 0));
    }
}