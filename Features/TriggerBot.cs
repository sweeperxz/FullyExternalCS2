using CS2Cheat.Data.Game;
using CS2Cheat.Utils;
using Keys = Process.NET.Native.Types.Keys;

namespace CS2Cheat.Features;

public class TriggerBot(GameProcess gameProcess, GameData gameData) : ThreadedServiceBase
{
    protected override string ThreadName => nameof(TriggerBot);

    private GameProcess GameProcess { get; set; } = gameProcess;

    private GameData GameData { get; set; } = gameData;

    private static Keys TriggerBotHotKey => Keys.LMenu;

    public override void Dispose()
    {
        base.Dispose();

        GameData = default;
        GameProcess = default;
    }

    public static bool IsHotKeyDown()
    {
        return TriggerBotHotKey.IsKeyDown();
    }

    protected override void FrameAction()
    {
        var entityId = GameProcess.Process.Read<int>(GameProcess.ModuleClient.Read<IntPtr>(Offsets.dwLocalPlayerPawn) +
                                                     Offsets.m_iIDEntIndex);
        if (!GameProcess.IsValid || !IsHotKeyDown()) return;

        if (entityId < 0) return;

        var entityEntry = GameProcess.Process.Read<IntPtr>(GameProcess.ModuleClient.Read<IntPtr>(Offsets.dwEntityList) +
                                                           0x8 * (entityId >> 9) + 0x10);
        var entity = GameProcess.Process.Read<IntPtr>(entityEntry + 120 * (entityId & 0x1FF));
        var entityTeam = GameProcess.Process.Read<int>(entity + Offsets.m_iTeamNum);


        var shouldTrigger = (GameData.Player.Team != entityTeam.ToTeam() || GameData.Player.FFlags == 65664) &&
                            Math.Abs(GameData.Player.Velocity.Z) <= 18f;

        if (!shouldTrigger) return;
        Task.Delay(5);
        Utility.MouseLeftDown();
        Utility.MouseLeftUp();
    }
}