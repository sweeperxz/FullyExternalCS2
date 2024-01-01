using CS2Cheat.Data;
using CS2Cheat.Gfx;
using Application = System.Windows.Application;
using Graphics = CS2Cheat.Gfx.Graphics;

namespace CS2Cheat;

public class Program :
    Application,
    IDisposable
{
    public static void Main()
    {
        new Program().Run();
    }
    
    private GameProcess GameProcess { get; set; }
    private GameData GameData { get; set; }

    private WindowOverlay WindowOverlay { get; set; }

    private Graphics Graphics { get; set; }


    private Program()
    {
        Startup += (_, _) => StartUp();
        Exit += (_, _) => Dispose();
    }


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