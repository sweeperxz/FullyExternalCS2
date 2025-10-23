using System.Windows;
using System.Windows.Threading;
using CS2Cheat.Data.Game;
using CS2Cheat.Utils;
using GameOverlay.Windows;
using SharpDX;
using static System.Windows.Application;
using Color = SharpDX.Color;
using Rectangle = System.Drawing.Rectangle;

namespace CS2Cheat.Graphics;

public class WindowOverlay : ThreadedServiceBase
{
    public WindowOverlay(GameProcess gameProcess)
    {
        GameProcess = gameProcess;

        FpsCounter = new FpsCounter();
        Window = new OverlayWindow
        {
            Title = "Overlay",
            IsTopmost = true,
            IsVisible = true,
            X = -32000,
            Y = -32000,
            Width = 16,
            Height = 16
        };

        Window.Create();
    }

    protected override string ThreadName => nameof(WindowOverlay);

    private GameProcess GameProcess { get; set; }

    public OverlayWindow Window { get; private set; }

    private static FpsCounter? FpsCounter { get; set; }

    private Window? MenuWindow { get; set; }


    public override void Dispose()
    {
        base.Dispose();

        Window.Dispose();
        Window = default;

        FpsCounter = default;
        GameProcess = default;

        if (MenuWindow != null)
        {
            Current.Dispatcher.Invoke(() => MenuWindow.Hide(), DispatcherPriority.Normal);
            MenuWindow = null;
        }
    }

    public void AttachMenuWindow(Window menuWindow)
    {
        MenuWindow = menuWindow;
    }

    protected override void FrameAction()
    {
        FpsCounter?.Update();
        Update(GameProcess.WindowRectangleClient);
    }

    private void Update(Rectangle windowRectangle)
    {
        Current.Dispatcher.Invoke(() =>
        {
            if (Window.X != windowRectangle.Location.X || Window.Y != windowRectangle.Location.Y ||
                Window.Width != windowRectangle.Size.Width || Window.Height != windowRectangle.Size.Height)
            {
                if (windowRectangle is { Width: > 0, Height: > 0 })
                {
                    Window.X = windowRectangle.Location.X;
                    Window.Y = windowRectangle.Location.Y;
                    Window.Width = windowRectangle.Size.Width;
                    Window.Height = windowRectangle.Size.Height;

                    if (MenuWindow != null)
                    {
                        MenuWindow.Left = windowRectangle.Left + 20;
                        MenuWindow.Top = windowRectangle.Top + 20;
                        if (MenuWindow.Visibility != Visibility.Visible)
                            MenuWindow.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    Window.X = -32000;
                    Window.Y = -32000;
                    Window.Width = 16;
                    Window.Height = 16;

                    if (MenuWindow != null && MenuWindow.Visibility != Visibility.Hidden)
                        MenuWindow.Visibility = Visibility.Hidden;
                }
            }
        }, DispatcherPriority.Normal);
    }

    public static void Draw(GameProcess gameProcess, Graphics graphics)
    {
        // window border
        graphics.DrawLine(Color.DarkGray,
            new Vector2(0, 0),
            new Vector2(gameProcess.WindowRectangleClient.Width - 1, 0),
            new Vector2(gameProcess.WindowRectangleClient.Width - 1, 0),
            new Vector2(gameProcess.WindowRectangleClient.Width - 1, gameProcess.WindowRectangleClient.Height - 1),
            new Vector2(gameProcess.WindowRectangleClient.Width - 1, gameProcess.WindowRectangleClient.Height - 1),
            new Vector2(0, gameProcess.WindowRectangleClient.Height - 1),
            new Vector2(0, gameProcess.WindowRectangleClient.Height - 1),
            new Vector2(0, 0)
        );
        //fps count
        graphics.FontConsolas32.DrawText(default, $"{FpsCounter!.Fps} FPS", 5, 5, Color.White);
    }
}