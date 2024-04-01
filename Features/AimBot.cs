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
    private const float AimBotSmoothing = 3f;

    private static readonly float AimFov = 15f.DegreeToRadian();

    private static double _anglePerPixel;

    private readonly object _stateLock = new();

    public AimBot(GameProcess gameProcess, GameData gameData)
    {
        GameProcess = gameProcess;
        GameData = gameData;
        MouseHook = new GlobalHook(HookType.WH_MOUSE_LL, MouseHookCallback);
    }

    private static MouseMoveMethod MouseMoveMethod =>
        MouseMoveMethod.TryMouseMoveNew;

    private static string AimBonePos => "pelvis";

    private bool IsCalibrated { get; set; }

    protected override string ThreadName => nameof(AimBot);

    private GameProcess GameProcess { get; set; }
    private GameData GameData { get; set; }
    private GlobalHook MouseHook { get; set; }
    private AimBotState State { get; set; }
    private float CurrentSmoothing { get; set; } = AimBotSmoothing;

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

        if (!GameProcess.IsValid || !GameData.Player.IsAlive() || TriggerBot.IsHotKeyDown() ||
            GameData.Player.IsGrenade()) return true;

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

        Point aimPixels;
        if (GetAimTarget(out var aimAngles))
        {
            GetAimPixels(aimAngles, out aimPixels);
        }
        else
        {
            aimPixels = Point.Empty;
            aimAngles = new Vector2(0, 0);
            var rand = new Random();
            var horizontalRecoil = rand.Next(-3, 4);
            var verticalRecoil = rand.Next(-5, 6);


            aimAngles.X += horizontalRecoil;
            aimAngles.Y += verticalRecoil;
        }

        var wait = TryMouseDown();
        wait |= MouseMoveMethod == MouseMoveMethod.TryMouseMoveOld
            ? TryMouseMoveOld(aimPixels)
            : TryMouseMoveNew(aimPixels);

        if (wait) Thread.Sleep(20);
    }


    private bool GetAimTarget(out Vector2 aimAngles)
    {
        var minAngleSize = float.MaxValue;
        aimAngles = new Vector2((float)Math.PI, (float)Math.PI);
        var targetFound = false;
        var aimPosition = Vector3.Zero;

        foreach (var entity in GameData.Entities.Where(entity =>
                     entity.IsAlive() && entity.AddressBase != GameData.Player.AddressBase &&
                     entity.Team != GameData.Player.Team && entity.IsSpotted))
        {
            aimPosition = entity.BonePos.TryGetValue(AimBonePos, out var entityBonePo)
                ? entityBonePo
                : entity.BonePos[AimBonePos];

            GetAimAngles(aimPosition, out var angleToBoneSize, out var anglesToBone);

            if (angleToBoneSize > AimFov) continue;

            if (angleToBoneSize < minAngleSize)
            {
                minAngleSize = angleToBoneSize;
                aimAngles = anglesToBone;
                targetFound = true;
            }
        }

        if (targetFound)
        {
            CurrentSmoothing = AimBotSmoothing;

            var distanceToTarget = Vector3.Distance(GameData.Player.EyePosition, aimPosition);
            var smoothingAcceleration = Math.Max(1.0f, distanceToTarget / 100.0f);

            CurrentSmoothing *= smoothingAcceleration;
            CurrentSmoothing = Math.Min(CurrentSmoothing, 50.0f);

            aimAngles *= 1 / Math.Max(CurrentSmoothing, 1);
        }
        else
        {
            CurrentSmoothing = AimBotSmoothing;
        }

        return targetFound;
    }


    private void GetAimAngles(Vector3 pointWorld, out float angleSize, out Vector2 aimAngles)
    {
        var aimDirection = GameData.Player.AimDirection;
        var aimDirectionDesired = (pointWorld - GameData.Player.EyePosition).GetNormalized();

        var horizontalAngle = aimDirectionDesired.GetSignedAngleTo(aimDirection, new Vector3(0, 0, 1));
        var verticalAngle = aimDirectionDesired.GetSignedAngleTo(aimDirection,
            Vector3.Cross(aimDirectionDesired, new Vector3(0, 0, 1)).GetNormalized());

        aimAngles = new Vector2(horizontalAngle, verticalAngle);


        angleSize = aimDirection.GetAngleTo(aimDirectionDesired);
    }


    private static void GetAimPixels(Vector2 aimAngles, out Point aimPixels)
    {
        var fovRatio = 90.0 / Player.Fov;
        aimPixels = new Point(
            (int)Math.Round(aimAngles.X / _anglePerPixel * fovRatio),
            (int)Math.Round(aimAngles.Y / _anglePerPixel * fovRatio)
        );
    }

    private static bool TryMouseMoveOld(Point aimPixels)
    {
        if (aimPixels is { X: 0, Y: 0 }) return false;
        Utility.MouseMove(aimPixels.X, aimPixels.Y);
        return true;
    }

    private static bool TryMouseMoveNew(Point aimPixels)
    {
        if (aimPixels is { X: 0, Y: 0 }) return false;
        Utility.WindMouseMove(0, 0, aimPixels.X, aimPixels.Y, 9.0, 3.0, 15.0, 12.0);
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
        _anglePerPixel = new[]
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