using CS2Cheat.Data.Game;
using CS2Cheat.Utils;
using WindowsInput.Native;

namespace CS2Cheat.Features;

public class TriggerBot(GameProcess gameProcess, GameData gameData) : ThreadedServiceBase
{
    protected override string ThreadName => nameof(TriggerBot);

    private GameProcess GameProcess { get; set; } = gameProcess;

    private GameData GameData { get; set; } = gameData;

    private static VirtualKeyCode TriggerBotHotKey => VirtualKeyCode.LMENU;

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

        if (GameData.Player.Team != entityTeam.ToTeam())
        {
            Task.Delay(5);
            Utility.MouseLeftDown();
            Utility.MouseLeftUp();
        }
    }
}