using System.Windows.Threading;
using CS2Cheat.Data;
using CS2Cheat.System;
using CS2Cheat.System.Data;
using CS2Cheat.Utils;
using static System.Windows.Application;
using Point = System.Drawing.Point;

namespace CS2Cheat.Gfx;

public class WindowOverlay : ThreadedServiceBase
{
    protected override TimeSpan ThreadFrameSleep { get; set; } = new(0, 0, 0, 0, 500);

    protected override string ThreadName => nameof(WindowOverlay);
    private GameProcess GameProcessManager { get; set; }

    public Form Window { get; private set; }

    public WindowOverlay(GameProcess gameProcessManager)
    {
        GameProcessManager = gameProcessManager;

        Window = new Form()
        {
            Name = "Overlay Window",
            Text = "Overlay Window",
            MinimizeBox = false,
            MaximizeBox = false,
            FormBorderStyle = FormBorderStyle.None,
            TopMost = true,
            Width = 16,
            Height = 16,
            Left = -32000,
            Top = -32000,
            StartPosition = FormStartPosition.Manual
        };

        Window.Load += (_, _) =>
        {
            var exStyle = User32.GetWindowLong(Window.Handle, User32.GWL_EXSTYLE);
            exStyle |= User32.WS_EX_LAYERED;
            exStyle |= User32.WS_EX_TRANSPARENT;

            // make the window's border completely transparent
            User32.SetWindowLong(Window.Handle, User32.GWL_EXSTYLE, (IntPtr)exStyle);

            // set the alpha on the whole window to 255 (solid)
            User32.SetLayeredWindowAttributes(Window.Handle, 0, 255, User32.LWA_ALPHA);
        };
        Window.SizeChanged += (_, _) => ExtendFrameIntoClientArea();
        Window.LocationChanged += (_, _) => ExtendFrameIntoClientArea();
        Window.Closed += (_, _) => Current.Shutdown();

        // show window
        Window.Show();
    }


    public override void Dispose()
    {
        base.Dispose();

        Window.Close();
        Window.Dispose();
        Window = default;

        GameProcessManager = default;
    }


    private void ExtendFrameIntoClientArea()
    {
        var margins = new Margins
        {
            Left = -1,
            Right = -1,
            Top = -1,
            Bottom = -1
        };
        Dwmapi.DwmExtendFrameIntoClientArea(Window.Handle, ref margins);
    }

    protected override void FrameAction()
    {
        Update(GameProcessManager.WindowRectangleClient);
    }

    private void Update(Rectangle windowRectangleClient)
    {
        Current.Dispatcher.Invoke(() =>
        {
            Window.TransparencyKey = Color.Magenta;
            Window.BackColor = Color.Magenta;


            if (Window.Location != windowRectangleClient.Location || Window.Size != windowRectangleClient.Size)
            {
                if (windowRectangleClient is { Width: > 0, Height: > 0 })
                {
                    // valid
                    Window.Location = windowRectangleClient.Location;
                    Window.Size = windowRectangleClient.Size;
                }
                else
                {
                    // invalid
                    Window.Location = new Point(-32000, -32000);
                    Window.Size = new Size(16, 16);
                }
            }
        }, DispatcherPriority.Normal);
    }
}