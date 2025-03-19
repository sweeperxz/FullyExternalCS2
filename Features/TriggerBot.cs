using CS2Cheat.Data.Game;
using CS2Cheat.Utils;
using System.Threading.Tasks;
using Keys = Process.NET.Native.Types.Keys;

namespace CS2Cheat.Features;

public sealed class TriggerBot : ThreadedServiceBase
{
    private const float MaxVelocityThreshold = 18f;
    private const int TriggerDelayMs = 5;
    private const int EntityListMultiplier = 0x8;
    private const int EntityEntryOffset = 0x10;
    private const int EntityStride = 120;
    private const int EntityIndexMask = 0x1FF;
    private const int EntityIndexShift = 9;

    protected override string ThreadName => nameof(TriggerBot);
    private static Keys TriggerBotHotKey => Keys.LMenu;

    private readonly GameProcess _gameProcess;
    private readonly GameData _gameData;

    public TriggerBot(GameProcess gameProcess, GameData gameData)
    {
        _gameProcess = gameProcess ?? throw new ArgumentNullException(nameof(gameProcess));
        _gameData = gameData ?? throw new ArgumentNullException(nameof(gameData));
    }

    protected override async void FrameAction()
    {
        if (!ShouldExecuteTriggerBot())
            return;

        var targetEntity = GetTargetEntity();
        if (targetEntity == IntPtr.Zero)
            return;

        var entityTeam = _gameProcess.Process.Read<int>(targetEntity + Offsets.m_iTeamNum);
        if (!ShouldTriggerOnEntity(entityTeam))
            return;

        await ExecuteTrigger();
    }

    private bool ShouldExecuteTriggerBot()
    {
        return _gameProcess.IsValid && IsHotKeyDown();
    }

    private IntPtr GetTargetEntity()
    {
        var localPlayerPawn = _gameProcess.ModuleClient.Read<IntPtr>(Offsets.dwLocalPlayerPawn);
        var entityId = _gameProcess.Process.Read<int>(localPlayerPawn + Offsets.m_iIDEntIndex);

        if (entityId < 0)
            return IntPtr.Zero;

        var entityList = _gameProcess.ModuleClient.Read<IntPtr>(Offsets.dwEntityList);
        var entityEntry = _gameProcess.Process.Read<IntPtr>(
            entityList + EntityListMultiplier * (entityId >> EntityIndexShift) + EntityEntryOffset);

        return _gameProcess.Process.Read<IntPtr>(
            entityEntry + EntityStride * (entityId & EntityIndexMask));
    }

    private bool ShouldTriggerOnEntity(int entityTeam)
    {
        var isDifferentTeam = _gameData.Player.Team != entityTeam.ToTeam();
        var isSpecialCondition = _gameData.Player.FFlags == 65664;
        var isWithinVelocityLimit = Math.Abs(_gameData.Player.Velocity.Z) <= MaxVelocityThreshold;

        return (isDifferentTeam || isSpecialCondition) && isWithinVelocityLimit;
    }

    private static async Task ExecuteTrigger()
    {
        await Task.Delay(TriggerDelayMs);
        Utility.MouseLeftDown();
        Utility.MouseLeftUp();
    }

    public static bool IsHotKeyDown() => TriggerBotHotKey.IsKeyDown();

    public override void Dispose()
    {
        base.Dispose();
        GC.SuppressFinalize(this);
    }
}