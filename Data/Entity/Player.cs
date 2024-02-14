using CS2Cheat.Core.Data;
using CS2Cheat.Data.Game;
using CS2Cheat.Graphics;
using CS2Cheat.Utils;
using SharpDX;
using Keys = Process.NET.Native.Types.Keys;

namespace CS2Cheat.Data.Entity;

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

    public Vector3 EyeDirection { get; private set; }

    public static int Fov => 90;

    private int FFlags { get; set; }


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


        MatrixViewProjection = Matrix.Transpose(gameProcess.ModuleClient.Read<Matrix>(Offsets.dwViewMatrix));
        MatrixViewport = Utility.GetMatrixViewport(gameProcess.WindowRectangleClient.Size);
        MatrixViewProjectionViewport = MatrixViewProjection * MatrixViewport;

        ViewOffset = gameProcess.Process.Read<Vector3>(AddressBase + Offsets.m_vecViewOffset);
        EyePosition = Origin + ViewOffset;
        ViewAngles = gameProcess.ModuleClient.Read<Vector3>(Offsets.dwViewAngles);
        AimPunchAngle = gameProcess.Process.Read<Vector3>(AddressBase + Offsets.m_AimPunchAngle);
        TargetedEntityIndex = gameProcess.Process.Read<int>(AddressBase + Offsets.m_iIDEntIndex);
        FFlags = gameProcess.Process.Read<int>(AddressBase + Offsets.m_fFlags);


        EyeDirection =
            GraphicsMath.GetVectorFromEulerAngles(ViewAngles.X.DegreeToRadian(), ViewAngles.Y.DegreeToRadian());
        AimDirection = AimDirection = GraphicsMath.GetVectorFromEulerAngles
        (
            (ViewAngles.X + AimPunchAngle.X * Offsets.WeaponRecoilScale).DegreeToRadian(),
            (ViewAngles.Y + AimPunchAngle.Y * Offsets.WeaponRecoilScale).DegreeToRadian()
        );
        /*
        for bunnyhop to work correctly you need to write this
        alias j "+jump;-jump";
        bind space j;
        bind rightarrow j;
        fps_max 32;
        fps_max 0;
        */


        if (Keys.Space.IsKeyDown() && (FFlags & 1) > 0)
        {
            Thread.Sleep(7);
            Utility.PressSpace();
        }


        return true;
    }

    public bool IsGrenade()
    {
        var grenades = new HashSet<string>
        {
            WeaponIndexes.Smokegrenade.ToString(),
            WeaponIndexes.Flashbang.ToString(),
            WeaponIndexes.Hegrenade.ToString()
        };

        return grenades.Contains(CurrentWeaponName);
    }
}