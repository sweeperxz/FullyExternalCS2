using CS2Cheat.Gfx;
using CS2Cheat.System;
using CS2Cheat.Utils;
using SharpDX;
using WindowsInput;
using WindowsInput.Native;

namespace CS2Cheat.Data;

public class Player
{
    #region properties

    public Matrix MatrixViewport { get; private set; }

    private Vector3 Origin { get; set; }

    private Vector3 ViewOffset { get; set; }

    public Vector3 PlayerPosition { get; private set; }

    private Vector3 ViewAngles { get; set; }

    public Vector3 AimPunchAngle { get; private set; }

    public Vector3 AimDirection { get; private set; }

    public int Fov { get; private set; }

    private int IdentityCrosshairIndex { get; set; }

    private InputSimulator InputSimulator { get; set; } = new();

    private int FFlags { get; set; }

    #endregion

    #region methods

    public void Update(GameProcess gameProcess)
    {
        var addressBase = gameProcess.ModuleClient.Read<IntPtr>(Offsets.dwLocalPlayerPawn);
        if (addressBase == IntPtr.Zero) return;

        MatrixViewport = GraphicsMath.GetMatrixViewport(gameProcess.WindowRectangleClient.Size);


        Origin = gameProcess.Process.Read<Vector3>(addressBase + Offsets.m_vOldOrigin);
        ViewOffset = gameProcess.Process.Read<Vector3>(addressBase + Offsets.m_vecViewOffset);

        PlayerPosition = Origin + ViewOffset;

        ViewAngles = gameProcess.Process.Read<Vector3>(addressBase + Offsets.m_angEyeAngles);
        AimPunchAngle = gameProcess.Process.Read<Vector3>(addressBase + Offsets.m_AimPunchAngle);
        Fov = gameProcess.Process.Read<int>(gameProcess.Process.Read<IntPtr>(addressBase + Offsets.m_pCameraServices) +
                                            Offsets.m_iFOVStart);

        IdentityCrosshairIndex = gameProcess.Process.Read<int>(addressBase + Offsets.m_iIDEntIndex);
        FFlags = gameProcess.Process.Read<int>(addressBase + Offsets.m_fFlags);

        if (User32.GetAsyncKeyState((int)Keys.LMenu) < 0)
            if (IdentityCrosshairIndex > 0)
                // User32.mouse_event(0x0002, 0, 0, 0, UIntPtr.Zero);
                // User32.mouse_event(0x0004, 0, 0, 0, UIntPtr.Zero);
                InputSimulator.Mouse.LeftButtonClick();


        /*alias _checkjump "-jump; alias checkjump";
        alias +j "+jump; alias checkjump _checkjump";
        alias -j "checkjump";
        bind "space" +j;*/


        if (User32.GetAsyncKeyState(0x20) < 0)
        {
            if (FFlags is PlayerState.Standing or PlayerState.Crouching)
                InputSimulator.Mouse.VerticalScroll(10); // memor.WriteUInt(forceJump, PlayerState.PlusJump);
            else
                InputSimulator.Mouse.VerticalScroll(-10); // memor.WriteUInt(forceJump, KeyEvent.MinusJump);
        }


        if (Fov == 0)
            Fov = 90; // correct for default

        // calc data
        AimDirection = GetAimDirection(ViewAngles, AimPunchAngle);
    }

    private static Vector3 GetAimDirection(Vector3 viewAngles, Vector3 aimPunchAngle)
    {
        var phi = (viewAngles.X + aimPunchAngle.X * Offsets.weapon_recoil_scale).DegreeToRadian();
        var theta = (viewAngles.Y + aimPunchAngle.Y * Offsets.weapon_recoil_scale).DegreeToRadian();

        // https://ru.wikipedia.org/wiki/%D0%A1%D1%84%D0%B5%D1%80%D0%B8%D1%87%D0%B5%D1%81%D0%BA%D0%B0%D1%8F_%D1%81%D0%B8%D1%81%D1%82%D0%B5%D0%BC%D0%B0_%D0%BA%D0%BE%D0%BE%D1%80%D0%B4%D0%B8%D0%BD%D0%B0%D1%82
        return Vector3.Normalize(new Vector3
        (
            MathF.Cos(phi) * MathF.Cos(theta),
            MathF.Cos(phi) * MathF.Sin(theta),
            -MathF.Sin(phi)
        ));
    }

    #endregion
}

public static class PlayerState
{
    public const int Standing = 65665;

    public const int Crouching = 65667;
}