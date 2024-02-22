using CS2Cheat.Utils;
using Color = SharpDX.Color;
using System.Diagnostics;

namespace CS2Cheat.Features;

internal class BombTimer(Graphics.Graphics graphics) : ThreadedServiceBase
{
    private IntPtr TempC4 { get; set; }

    private IntPtr PlantedC4 { get; set; }

    private static string BombPlanted { get; set; } = null!;

    private static string BombSite { get; set; } = null!;

    private static readonly Stopwatch BombTime = new();

    protected override void FrameAction()
    {
        graphics.GameProcess.ModuleClient.Read<IntPtr>(
            graphics.GameProcess.ModuleClient.Read<int>(Offsets.dwGlobalVars));

        TempC4 = graphics.GameProcess.ModuleClient.Read<IntPtr>(Offsets.dwPlantedC4);
        PlantedC4 = graphics.GameProcess.Process.Read<IntPtr>(TempC4);

        var isBombPlanted = graphics.GameProcess.ModuleClient.Read<bool>(Offsets.dwPlantedC4 - 0x8);

        switch (isBombPlanted)
        {
            case true when !BombTime.IsRunning:
                BombTime.Start();
                BombSite = graphics.GameProcess.Process.Read<int>(PlantedC4 + Offsets.m_nBombSite) == 1
                    ? BombSite = "B"
                    : BombSite = "A";
                break;
            case false when BombTime.IsRunning:
                BombTime.Reset();
                BombSite = null!;
                break;
        }

        if (BombTime.Elapsed.TotalSeconds >= 40)
        {
            BombTime.Stop();
            BombPlanted = default!;
            BombSite = default!;
        }

        BombPlanted = isBombPlanted
            ? "Bomb is planted on site: "
            : string.Empty;

        graphics.GameProcess.Process.Read<bool>(PlantedC4 + Offsets.m_bBombDefused);
    }


    public static void Draw(Graphics.Graphics graphics)
    {
        var timerText = BombTime.IsRunning
            ? $"Time left: {40 - BombTime.Elapsed.TotalSeconds:F0} seconds"
            : " ";

        graphics.FontAzonix64.DrawText(default, $"{BombPlanted + (BombSite ?? "") + Environment.NewLine + timerText}",
            0, 500, Color.WhiteSmoke);
    }
}