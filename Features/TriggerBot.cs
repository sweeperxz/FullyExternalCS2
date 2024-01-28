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

    private InputSimulator InputSimulator { get; } = new();


    public override void Dispose()
    {
        base.Dispose();

        GameData = default;
        GameProcess = default;
    }

    public static bool IsHotKeyDown()
    {
        return WindowsVirtualKey.VK_MBUTTON.IsKeyDown();
    }

    protected override void FrameAction()
    {
        var entityId = GameProcess.Process.Read<int>(GameProcess.ModuleClient.Read<IntPtr>(Offsets.dwLocalPlayerPawn) +
                                                     Offsets.m_iIDEntIndex);
        if (!GameProcess.IsValid || !InputSimulator.InputDeviceState.IsKeyDown(VirtualKeyCode.LMENU)) return;

        if (entityId < 0) return;

        var entityEntry = GameProcess.Process.Read<IntPtr>(GameProcess.ModuleClient.Read<IntPtr>(Offsets.dwEntityList) +
                                                           0x8 * (entityId >> 9) + 0x10);
        var entity = GameProcess.Process.Read<IntPtr>(entityEntry + 120 * (entityId & 0x1FF));
        var entityTeam = GameProcess.Process.Read<int>(entity + Offsets.m_iTeamNum);

        if (GameData.Player.Team != entityTeam.ToTeam())
        {
            Task.Delay(5);
            InputSimulator.Mouse.LeftButtonClick();
        }
    }
}