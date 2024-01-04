using CS2Cheat.Gfx;
using CS2Cheat.Utils;
using Process.NET.Extensions;
using SharpDX;
using WindowsInput;
using WindowsInput.Native;

namespace CS2Cheat.Data;

public class Player : EntityBase
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

    private InputSimulator InputSimulator { get; } = new();

    private int FFlags { get; set; }

    #endregion

    #region methods

    protected override IntPtr ReadAddressBase(GameProcess gameProcess)
    {
        return gameProcess.ModuleClient.Read<IntPtr>(Offsets.dwLocalPlayerPawn);
    }

    public override bool Update(GameProcess gameProcess)
    {
        if (!base.Update(gameProcess))
        {
            return false;
        }

        MatrixViewport = GraphicsMath.GetMatrixViewport(gameProcess.WindowRectangleClient.Size);


        Origin = gameProcess.Process.Read<Vector3>(AddressBase + Offsets.m_vOldOrigin);
        ViewOffset = gameProcess.Process.Read<Vector3>(AddressBase + Offsets.m_vecViewOffset);

        PlayerPosition = Origin + ViewOffset;

        ViewAngles = gameProcess.Process.Read<Vector3>(AddressBase + Offsets.m_angEyeAngles);
        AimPunchAngle = gameProcess.Process.Read<Vector3>(AddressBase + Offsets.m_AimPunchAngle);
        Fov = gameProcess.Process.Read<int>(gameProcess.Process.Read<IntPtr>(AddressBase + Offsets.m_pCameraServices) +
                                            Offsets.m_iFOVStart);

        IdentityCrosshairIndex = gameProcess.Process.Read<int>(AddressBase + Offsets.m_iIDEntIndex);
        FFlags = gameProcess.Process.Read<int>(AddressBase + Offsets.m_fFlags);
        


        /* bind mwheelup +jump
         bind mwheeldown -jump
         alias _checkjump "-jump; alias checkjump";
         alias +j "+jump; alias checkjump _checkjump";
         alias -j "checkjump";
         bind "space" +j;
         fps_max 32;
         fps_max 0;
         */
        // var EntityList = gameProcess.ModuleClient.Read<IntPtr>(Offsets.dwEntityList);
        // var ListEntry = gameProcess.Process.Read<IntPtr>(EntityList + 0x10);
        //
        // for (int i = 0; i < 64; i++)
        // {
        //     if (ListEntry == IntPtr.Zero)
        //     {
        //         continue;
        //     }
        //
        //     var CurrentController = gameProcess.Process.Read<IntPtr>(ListEntry + i * 0x78);
        //     if (CurrentController == IntPtr.Zero)
        //     {
        //         continue;
        //     }
        //
        //     int pawnHandle = gameProcess.Process.Read<int>(CurrentController + Offsets.m_hPlayerPawn);
        //     if (pawnHandle is 0)
        //     {
        //         continue;
        //     }
        //
        //     var ListEntry2 = gameProcess.Process.Read<IntPtr>(EntityList + 0x8 * ((pawnHandle & 0x7FFF) >> 9) + 0x10);
        //     var CurrentPawn = gameProcess.Process.Read<IntPtr>(ListEntry2 + 0x78 * (pawnHandle & 0x1FF));
        //
        //     var team = gameProcess.Process.Read<int>(CurrentPawn + Offsets.m_iTeamNum);
        //     Console.WriteLine(team);
        // }

        if (InputSimulator.InputDeviceState.IsKeyDown(VirtualKeyCode.SPACE))
        {
            if (FFlags is PlayerState.Standing or PlayerState.Crouching)
                InputSimulator.Mouse.VerticalScroll(10);
            else
                InputSimulator.Mouse.VerticalScroll(-10);
        }


        if (Fov == 0)
            Fov = 90; // correct for default

        // calc data
        AimDirection = GetAimDirection(ViewAngles, AimPunchAngle);
        return true;
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