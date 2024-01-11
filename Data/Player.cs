using CS2Cheat.Data.Entity;
using CS2Cheat.Data.Game;
using CS2Cheat.Utils;
using SharpDX;
using WindowsInput;
using WindowsInput.Native;

namespace CS2Cheat.Data;

public class Player : EntityBase
{
    private Matrix MatrixViewProjection { get; set; }
    public Matrix MatrixViewport { get; private set; }
    public Matrix MatrixViewProjectionViewport { get; private set; }
    private Vector3 ViewOffset { get; set; }
    public Vector3 EyePosition { get; private set; }
    private Vector3 ViewAngles { get; set; }
    public Vector3 AimPunchAngle { get; private set; }
    public Vector3 AimDirection { get; private set; }
    public int TargetedEntityIndex { get; private set; }

    private int FFlags { get; set; }

    private InputSimulator InputSimulator { get; } = new();


    protected override IntPtr ReadControllerBase(GameProcess gameProcess)
    {
        return gameProcess.ModuleClient.Read<IntPtr>(Offsets.dwLocalPlayerController);
    }

    protected override IntPtr ReadAddressBase(GameProcess gameProcess)
    {
        return gameProcess.ModuleClient.Read<IntPtr>(Offsets.dwLocalPlayerPawn);
    }

    public override bool Update(GameProcess gameProcess)
    {
        if (!base.Update(gameProcess)) return false;


        /* bind mwheelup +jump
     bind mwheeldown -jump
     alias _checkjump "-jump; alias checkjump";
     alias +j "+jump; alias checkjump _checkjump";
     alias -j "checkjump";
     bind "space" +j;
     fps_max 32;
     fps_max 0;*/

        MatrixViewProjection = Matrix.Transpose(gameProcess.ModuleClient.Read<Matrix>(Offsets.dwViewMatrix));
        MatrixViewport = Utility.GetMatrixViewport(gameProcess.WindowRectangleClient.Size);
        MatrixViewProjectionViewport = MatrixViewProjection * MatrixViewport;

        ViewOffset = gameProcess.Process.Read<Vector3>(AddressBase + Offsets.m_vecViewOffset);
        EyePosition = Origin + ViewOffset;
        ViewAngles = gameProcess.ModuleClient.Read<Vector3>(Offsets.dwViewAngles);
        AimPunchAngle = gameProcess.Process.Read<Vector3>(AddressBase + Offsets.m_AimPunchAngle);
        TargetedEntityIndex = gameProcess.Process.Read<int>(AddressBase + Offsets.m_iIDEntIndex);
        FFlags = gameProcess.Process.Read<int>(AddressBase + Offsets.m_fFlags);

        AimDirection = GetAimDirection(ViewAngles, AimPunchAngle);

        if (InputSimulator.InputDeviceState.IsKeyDown(VirtualKeyCode.SPACE))
        {
            if (FFlags is PlayerState.Standing or PlayerState.Crouching)
                InputSimulator.Mouse.VerticalScroll(10);
            else
                InputSimulator.Mouse.VerticalScroll(-10);
        }


        return true;
    }

    private static Vector3 GetAimDirection(Vector3 viewAngles, Vector3 aimPunchAngle)
    {
        var phi = (viewAngles.X + aimPunchAngle.X * Offsets.weapon_recoil_scale).DegreeToRadian();
        var theta = (viewAngles.Y + aimPunchAngle.Y * Offsets.weapon_recoil_scale).DegreeToRadian();

        return Vector3.Normalize(new Vector3
        (
            (float)(Math.Cos(phi) * Math.Cos(theta)),
            (float)(Math.Cos(phi) * Math.Sin(theta)),
            (float)-Math.Sin(phi)
        ));
    }
}

public static class PlayerState
{
    public const int Standing = 65665;

    public const int Crouching = 65667;
}