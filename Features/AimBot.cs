using CS2Cheat.Core;
using CS2Cheat.Core.Data;
using CS2Cheat.Data.Entity;
using CS2Cheat.Data.Game;
using CS2Cheat.Graphics;
using CS2Cheat.Utils;
using Process.NET.Native.Types;
using SharpDX;
using Point = System.Drawing.Point;


namespace CS2Cheat.Features;

public class AimBot : ThreadedServiceBase
{
    /// <summary>
    ///     Smooth for aimbot, the higher the value the smoother it is
    /// </summary>
    private const float AimBotSmoothing = 1f;

    /// <summary>
    ///     FOV aimbot, the higher the value, the higher the radius of enemy detection.
    /// </summary>
    private static readonly float AimBotFov = 30f.DegreeToRadian();

    private readonly object _stateLock = new();

    public AimBot(GameProcess gameProcess, GameData gameData)
    {
        GameProcess = gameProcess;
        GameData = gameData;
        MouseHook = new GlobalHook(HookType.WH_MOUSE_LL, MouseHookCallback);
    }

    private double AnglePerPixel { get; set; } = 0.00069;
    private bool IsCalibrated { get; set; }

    /// <summary>
    ///     A bone to aim for
    /// </summary>
    private static string AimBonePos => "head";

    protected override string ThreadName => nameof(AimBot);

    private GameProcess GameProcess { get; set; }
    private GameData GameData { get; set; }
    private GlobalHook MouseHook { get; set; }
    private AimBotState State { get; set; }

    public override void Dispose()
    {
        base.Dispose();

        MouseHook.Dispose();
        MouseHook = null;

        GameData = null;
        GameProcess = null;
    }

    private IntPtr MouseHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        return nCode < 0 || ProcessMouseMessage((MouseMessages)wParam)
            ? User32.CallNextHookEx(MouseHook.HookHandle, nCode, wParam, lParam)
            : new IntPtr(1);
    }

    private bool ProcessMouseMessage(MouseMessages mouseMessage)
    {
        if (mouseMessage == MouseMessages.WmLButtonUp)
        {
            if (Monitor.TryEnter(_stateLock))
            {
                State = AimBotState.Up;
                Monitor.Exit(_stateLock);
            }

            return true;
        }

        if (mouseMessage != MouseMessages.WmLButtonDown) return true;

        if (!GameProcess.IsValid || !GameData.Player.IsAlive() || TriggerBot.IsHotKeyDown()) return true;

        if (Monitor.TryEnter(_stateLock))
        {
            if (State == AimBotState.Up) State = AimBotState.DownSuppressed;

            Monitor.Exit(_stateLock);
        }

        return true;
    }

    protected override void FrameAction()
    {
        if (!GameProcess.IsValid || !GameData.Player.IsAlive()) return;

        if (!IsCalibrated)
        {
            Calibrate();
            IsCalibrated = true;
        }

        if (Monitor.TryEnter(_stateLock))
        {
            if (State == AimBotState.Up)
            {
                Monitor.Exit(_stateLock);
                return;
            }

            Monitor.Exit(_stateLock);
        }

        var aimPixels = Point.Empty;
        if (GetAimTarget(out var aimAngles)) GetAimPixels(aimAngles, out aimPixels);

        var wait = TryMouseDown();
        wait |= TryMouseMove(aimPixels);

        if (wait) Thread.Sleep(20);
    }


    private bool GetAimTarget(out Vector2 aimAngles)
    {
        var minAngleSize = float.MaxValue;
        aimAngles = new Vector2((float)Math.PI, (float)Math.PI);
        var targetFound = false;

        foreach (var entity in GameData.Entities.Where(entity =>
                     entity.IsAlive() && entity.AddressBase != GameData.Player.AddressBase &&
                     entity.Team != GameData.Player.Team && entity.IsSpotted))
        {
            GetAimAngles(entity.BonePos[AimBonePos], out var angleToBoneSize, out var anglesToBone);

            if (angleToBoneSize > AimBotFov) continue;

            if (angleToBoneSize < minAngleSize)
            {
                minAngleSize = angleToBoneSize;
                aimAngles = anglesToBone;
                targetFound = true;
            }
        }

        if (targetFound) aimAngles *= 1 / Math.Max(AimBotSmoothing, 1);

        return targetFound;
    }

    private void GetAimAngles(Vector3 pointWorld, out float angleSize, out Vector2 aimAngles)
    {
        var aimDirection = GameData.Player.AimDirection;
        var aimDirectionDesired = (pointWorld - GameData.Player.EyePosition).GetNormalized();

        angleSize = aimDirection.GetAngleTo(aimDirectionDesired);

        aimAngles = new Vector2(
            aimDirectionDesired.GetSignedAngleTo(aimDirection, new Vector3(0, 0, 1)),
            aimDirectionDesired.GetSignedAngleTo(aimDirection,
                Vector3.Cross(aimDirectionDesired, new Vector3(0, 0, 1)).GetNormalized())
        );
    }

    private void GetAimPixels(Vector2 aimAngles, out Point aimPixels)
    {
        var fovRatio = 90.0 / Player.Fov;
        aimPixels = new Point(
            (int)Math.Round(aimAngles.X / AnglePerPixel * fovRatio),
            (int)Math.Round(aimAngles.Y / AnglePerPixel * fovRatio)
        );
    }

    private static bool TryMouseMove(Point aimPixels)
    {
        if (aimPixels is { X: 0, Y: 0 }) return false;
        Utility.MouseMove(aimPixels.X, aimPixels.Y);
        return true;
    }

    private bool TryMouseDown()
    {
        var mouseDown = false;

        if (Monitor.TryEnter(_stateLock))
        {
            if (State == AimBotState.DownSuppressed)
            {
                mouseDown = true;
                State = AimBotState.Down;
            }

            Monitor.Exit(_stateLock);
        }

        if (mouseDown) Utility.MouseLeftDown();

        return mouseDown;
    }

    private void Calibrate()
    {
        AnglePerPixel = new[]
        {
            CalibrationMeasureAnglePerPixel(100),
            CalibrationMeasureAnglePerPixel(-200),
            CalibrationMeasureAnglePerPixel(300),
            CalibrationMeasureAnglePerPixel(-400),
            CalibrationMeasureAnglePerPixel(200)
        }.Average();
        Console.WriteLine("[+] Mouse calibrate successful!");
    }

    private double CalibrationMeasureAnglePerPixel(int deltaPixels)
    {
        Thread.Sleep(100);
        var eyeDirectionStart = GameData.Player.EyeDirection;
        eyeDirectionStart.Z = 0;

        Utility.MouseMove(deltaPixels, 0);

        Thread.Sleep(100);
        var eyeDirectionEnd = GameData.Player.EyeDirection;
        eyeDirectionEnd.Z = 0;

        return eyeDirectionEnd.GetAngleTo(eyeDirectionStart) / Math.Abs(deltaPixels);
    }
}