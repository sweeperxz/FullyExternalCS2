using CS2Cheat.Data;
using CS2Cheat.Data.Game;
using CS2Cheat.Utils;
using WindowsInput;
using WindowsInput.Native;

namespace CS2Cheat.Features;

public class TriggerBot(GameProcess gameProcess, GameData gameData) : ThreadedServiceBase
{
    protected override string ThreadName => nameof(TriggerBot);

    private GameProcess GameProcess { get; set; } = gameProcess;

    private GameData GameData { get; set; } = gameData;

    private InputSimulator InputSimulator { get; set; } = new();


    public override void Dispose()
    {
        base.Dispose();

        GameData = default;
        GameProcess = default;
    }


    protected override void FrameAction()
    {
        var entityId = gameProcess.Process.Read<int>(gameProcess.ModuleClient.Read<IntPtr>(Offsets.dwLocalPlayerPawn) +
                                                     Offsets.m_iIDEntIndex);
        if (!GameProcess.IsValid || !InputSimulator.InputDeviceState.IsKeyDown(VirtualKeyCode.LMENU)) return;

        if (entityId < 0) return;

        var entityEntry = gameProcess.Process.Read<IntPtr>(gameProcess.ModuleClient.Read<IntPtr>(Offsets.dwEntityList) +
                                                           0x8 * (entityId >> 9) + 0x10);
        var entity = gameProcess.Process.Read<IntPtr>(entityEntry + 120 * (entityId & 0x1FF));
        var entityTeam = gameProcess.Process.Read<int>(entity + Offsets.m_iTeamNum);

        if (gameData.Player.Team == entityTeam.ToTeam()) return;
        Thread.Sleep(5);
        InputSimulator.Mouse.LeftButtonClick();
    }
}