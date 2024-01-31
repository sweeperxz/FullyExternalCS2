using CS2Cheat.Data.Game;
using CS2Cheat.Features;
using CS2Cheat.Graphics;
using CS2Cheat.Utils;
using static CS2Cheat.Core.User32;
using Application = System.Windows.Application;

namespace CS2Cheat;

/// <summary>
///     Main program class for the CS2Cheat application.
/// </summary>
public class Program :
    Application,
    IDisposable
{
    /// <summary />
    private Program()
    {
        Offsets.UpdateOffsets();
        Startup += (_, _) => InitializeComponent();
        Exit += (_, _) => Dispose();
    }

    /// <inheritdoc cref="GameProcess" />
    private GameProcess GameProcess { get; set; }

    /// <inheritdoc cref="GameData" />
    private GameData GameData { get; set; }

    /// <inheritdoc cref="WindowOverlay" />
    private WindowOverlay WindowOverlay { get; set; }

    /// <inheritdoc cref="Graphics" />

    private Graphics.Graphics Graphics { get; set; }

    private TriggerBot Trigger { get; set; }

    private AimBot AimBot { get; set; }

    /// <inheritdoc />
    public void Dispose()
    {
        GameProcess.Dispose();
        GameProcess = default;

        GameData.Dispose();
        GameData = default;

        WindowOverlay.Dispose();
        WindowOverlay = default;

        Graphics.Dispose();
        Graphics = default;

        Trigger.Dispose();
        Trigger = default;

        AimBot.Dispose();
        AimBot = default;
    }

    /// <summary />
    public static void Main()
    {
        new Program().Run();
    }


    /// <summary />
    private void InitializeComponent()
    {
        GameProcess = new GameProcess();
        GameProcess.Start();

        GameData = new GameData(GameProcess);
        GameData.Start();

        WindowOverlay = new WindowOverlay(GameProcess);
        WindowOverlay.Start();

        Graphics = new Graphics.Graphics(GameProcess, GameData, WindowOverlay);
        Graphics.Start();

        Trigger = new TriggerBot(GameProcess, GameData);
        Trigger.Start();

        AimBot = new AimBot(GameProcess, GameData);
        AimBot.Start();

        SetWindowDisplayAffinity(WindowOverlay!.Window.Handle, 0x00000011); //obs bypass
    }
}