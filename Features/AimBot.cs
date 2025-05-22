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

    private static string AimBonePos => "head";

    private bool IsCalibrated { get; set; }

    protected override string ThreadName => nameof(AimBot);

    private GameProcess? GameProcess { get; set; }
    private GameData? GameData { get; set; }
    private GlobalHook? MouseHook { get; set; }
    private AimBotState State { get; set; }
    private float CurrentSmoothing { get; set; } = AimBotSmoothing;

    public override void Dispose()
    {
        base.Dispose();

        if (MouseHook != null)
        {
            MouseHook.Dispose();
            MouseHook = null;
        }

        GameData = null;
        GameProcess = null;
    }

    private IntPtr MouseHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        return nCode < 0 || ProcessMouseMessage((MouseMessages)wParam)
            ? User32.CallNextHookEx(MouseHook != null ? MouseHook.HookHandle : IntPtr.Zero, nCode, wParam, lParam)
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

        if (GameProcess == null || !GameProcess.IsValid ||
            GameData == null || GameData.Player == null || !GameData.Player.IsAlive() ||
            TriggerBot.IsHotKeyDown() ||
            GameData.Player.IsGrenade())
        {
            return true;
        } 

        if (Monitor.TryEnter(_stateLock))
        {
            if (State == AimBotState.Up) State = AimBotState.DownSuppressed;

            Monitor.Exit(_stateLock);
        }

        return true;
    }
    protected override void FrameAction()
    {
        if (GameProcess == null || !GameProcess.IsValid || GameData?.Player == null || !GameData.Player.IsAlive())
        {
            return;
        }

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

        Point aimPixels = Point.Empty;
        Vector2 aimAngles;

        if (GetAimTarget(out aimAngles))
        {
            if (!float.IsNaN(aimAngles.X) && !float.IsNaN(aimAngles.Y))
            {
                GetAimPixels(aimAngles, out aimPixels);
            }
        }

        // Clamp pixel movement to prevent huge jumps (which cause spinning)
        aimPixels.X = Math.Max(Math.Min(aimPixels.X, 50), -50);
        aimPixels.Y = Math.Max(Math.Min(aimPixels.Y, 50), -50);

        bool shouldWait = TryMouseDown();

        if (MouseMoveMethod == MouseMoveMethod.TryMouseMoveOld)
        {
            shouldWait |= TryMouseMoveOld(aimPixels);
        }
        else
        {
            shouldWait |= TryMouseMoveNew(aimPixels);
        }

        if (shouldWait)
        {
            Thread.Sleep(20);
        }
    }


    private bool GetAimTarget(out Vector2 aimAngles)
    {
        var minAngleSize = float.MaxValue;
        aimAngles = new Vector2((float)Math.PI, (float)Math.PI);
        var targetFound = false;
        var aimPosition = Vector3.Zero;

        if (GameData != null && GameData.Entities != null)
        {
            foreach (var entity in GameData.Entities.Where(entity =>
                         GameData.Player != null &&
                         entity.IsAlive() && entity.AddressBase != GameData.Player.AddressBase &&
                         entity.Team != GameData.Player.Team && entity.IsSpotted))
            {
                aimPosition = entity.BonePos.TryGetValue(AimBonePos, out var entityBonePo)
                    ? entityBonePo
                    : entity.BonePos[AimBonePos];

                GetAimAngles(aimPosition, out var angleToBoneSize, out var anglesToBone);

                if (angleToBoneSize > AimFov)
                {
                    continue;
                }

                if (angleToBoneSize < minAngleSize)
                {
                    minAngleSize = angleToBoneSize;
                    aimAngles = anglesToBone;
                    targetFound = true;
                }
            }
        }

        CurrentSmoothing = AimBotSmoothing;
        if (targetFound)
        {
            float distanceToTarget = 0.0f;
            if (GameData != null && GameData.Player != null)
            {
                distanceToTarget = Vector3.Distance(GameData.Player.EyePosition, aimPosition);
            }
            var smoothingAcceleration = Math.Max(1.0f, distanceToTarget / 100.0f);

            CurrentSmoothing *= smoothingAcceleration;
            CurrentSmoothing = Math.Min(CurrentSmoothing, 50.0f);

            aimAngles *= 1 / Math.Max(CurrentSmoothing, 1);
        }

        return targetFound;
    }


    private void GetAimAngles(Vector3 pointWorld, out float angleSize, out Vector2 aimAngles)
    {
        aimAngles = Vector2.Zero;
        angleSize = 0f;

        if (GameData == null || GameData.Player == null)
        {
            return;
        }

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
        if (aimPixels.X == 0 && aimPixels.Y == 0)
        {
            return false;
        }
        if (Math.Abs(aimPixels.X) > 100 || Math.Abs(aimPixels.Y) > 100)
            {
                return false;
            }
        Utility.MouseMove(aimPixels.X, aimPixels.Y);
        return true;
    }

    private static bool TryMouseMoveNew(Point aimPixels)
    {
        if (aimPixels.X == 0 && aimPixels.Y == 0)
        {
            return false;
        }

        if (Math.Abs(aimPixels.X) > 100 || Math.Abs(aimPixels.Y) > 100)
        {
            return false;
        }
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

        if (GameData == null || GameData.Player == null)
        {
            return 0.0;
        }

        var eyeDirectionStart = GameData.Player.EyeDirection;
        eyeDirectionStart.Z = 0;

        Utility.MouseMove(deltaPixels, 0);

        Thread.Sleep(100);

        if (GameData == null || GameData.Player == null)
        {
            return 0.0;
        }

        var eyeDirectionEnd = GameData.Player.EyeDirection;
        eyeDirectionEnd.Z = 0;

        return eyeDirectionEnd.GetAngleTo(eyeDirectionStart) / Math.Abs(deltaPixels);
    }
}