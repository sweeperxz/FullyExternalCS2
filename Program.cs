using CS2Cheat.Data;
using CS2Cheat.Gfx;
using Application = System.Windows.Application;
using Graphics = CS2Cheat.Gfx.Graphics;

namespace CS2Cheat;

/// <summary>
/// Main program class for the CS2Cheat application.
/// </summary>
public class Program :
    Application,
    IDisposable
{
    /// <summary />
    public static void Main()
    {
        new Program().Run();
    }

    /// <inheritdoc cref="GameProcess"/>
    private GameProcess GameProcess { get; set; }

    /// <inheritdoc cref="GameData"/>
    private GameData GameData { get; set; }

    /// <inheritdoc cref="WindowOverlay"/>
    private WindowOverlay WindowOverlay { get; set; }

    /// <inheritdoc cref="Graphics"/>

    private Graphics Graphics { get; set; }


    /// <summary />
    private Program()
    {
        Startup += (_, _) => StartUp();
        Exit += (_, _) => Dispose();
    }


    /// <summary />
    private void StartUp()
    {
        GameProcess = new GameProcess();
        GameProcess.Start();

        GameData = new GameData(GameProcess);
        GameData.Start();

        WindowOverlay = new WindowOverlay(GameProcess);
        WindowOverlay.Start();

        Graphics = new Graphics(WindowOverlay, GameProcess, GameData);
        Graphics.Start();
    }

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
    }
}