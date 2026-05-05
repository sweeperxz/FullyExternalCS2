using CS2Cheat.Data.Game;
using CS2Cheat.Graphics;
using CS2Cheat.Utils;

namespace CS2Cheat;

public class Program
{
    public static async Task Main()
    {
        Console.WriteLine("[INFO] FullyExternalCS2 v2.0 (ImGui Edition)");
        Console.WriteLine("[INFO] Updating offsets...");

        await Offsets.UpdateOffsets();
        Console.WriteLine("[INFO] Offsets updated successfully.");

        Console.WriteLine("[INFO] Waiting for CS2 process...");
        var gameProcess = new GameProcess();
        gameProcess.Start();

        while (!gameProcess.IsValid || gameProcess.WindowRectangleClient.Width <= 0)
        {
            Thread.Sleep(500);
            Console.Write(".");
        }

        Console.WriteLine();
        Console.WriteLine($"[INFO] CS2 found. Window: {gameProcess.WindowRectangleClient.Width}x{gameProcess.WindowRectangleClient.Height}");

        var gameData = new GameData(gameProcess);
        gameData.Start();

        Thread.Sleep(2000);

        Console.WriteLine("[INFO] Starting overlay...");

        var overlay = new OverlayRenderer(gameProcess, gameData);
        overlay.StartFeatures();

        Console.WriteLine("[INFO] Overlay started. Press INSERT to toggle menu.");
        Console.WriteLine("[INFO] Close this console window to exit.");

        await overlay.Run();

        overlay.StopFeatures();
        gameData.Dispose();
        gameProcess.Dispose();
    }
}