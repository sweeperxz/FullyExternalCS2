using System.Windows.Threading;
using CS2Cheat.Data.Entity;
using CS2Cheat.Data.Game;
using CS2Cheat.Graphics;
using CS2Cheat.Utils;
using SharpDX;
using WindowsInput;
using WindowsInput.Native;
using static System.Windows.Application;

namespace CS2Cheat.Features;

public class AimBot(GameProcess gameProcess, GameData gameData) : ThreadedServiceBase
{
    private const VirtualKeyCode AimKey = VirtualKeyCode.LBUTTON;
    protected override string ThreadName => nameof(AimBot);
    protected override TimeSpan ThreadFrameSleep => TimeSpan.FromMilliseconds(5);

    private static int MaxFov => 100; //max fov
    private static int MinFov => 1; //min fov
    private static float MouseMoveSpeed => 5.5f; //smooth the higher the number, the faster the enemy is targeted.

    private static bool IsPress { get; set; }
    private GameProcess GameProcess { get; set; } = gameProcess;
    private GameData GameData { get; set; } = gameData;
    private InputSimulator InputSimulator { get; set; } = new();


    protected override void FrameAction()
    {
        if (!GameProcess.IsValid)
            return;

        Current.Dispatcher.Invoke(() => { IsPress = InputSimulator.InputDeviceState.IsKeyDown(AimKey); },
            DispatcherPriority.Normal);

        if (!IsPress) return;

        var bonePos = (from entity in GameData.Entities
            where IsValidAimTarget(entity)
            select entity.BonePos["head"]
            into worldPos
            select GameData.Player.MatrixViewProjectionViewport.Transform(worldPos)
            into transformed
            where transformed.Z < 1
            select new Vector2(transformed.X, transformed.Y)).ToList();

        var crosshair = EspAimCrosshair.GetPositionScreen(GameProcess, GameData);
        var crosshairScreen = new Vector2(crosshair.X, crosshair.Y);

        var target = Vector2.Zero;
        var distance = float.MaxValue;

        foreach (var t in bonePos)
        {
            var newDist = (crosshairScreen - t).Length();
            if (newDist < distance)
            {
                target = t;
                distance = newDist;
            }
        }

        if (distance > MaxFov) return;

        if (distance < MinFov) return;

        var diff = target - crosshairScreen;
        diff.Normalize();
        diff *= MouseMoveSpeed;


        InputSimulator.Mouse.MoveMouseBy((int)diff.X, (int)diff.Y);
    }

    private bool IsValidAimTarget(Entity entity)
    {
        return entity != null && entity.IsAlive() && entity.AddressBase != GameData.Player.AddressBase &&
               entity.Team != GameData.Player.Team;
    }

    public override void Dispose()
    {
        base.Dispose();
        GameProcess = default;
        GameData = default;
        InputSimulator = default;
    }
}