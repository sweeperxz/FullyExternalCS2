using System.Media;
using System.Numerics;
using CS2Cheat.Core.Data;
using CS2Cheat.Data.Game;
using CS2Cheat.Graphics;
using CS2Cheat.Utils;

namespace CS2Cheat.Data.Entity;

public class Player : EntityBase
{
    private Matrix4x4 MatrixViewProjection { get; set; }
    public Matrix4x4 MatrixViewport { get; private set; }
    public Matrix4x4 MatrixViewProjectionViewport { get; private set; }
    private Vector3 ViewOffset { get; set; }
    public Vector3 EyePosition { get; private set; }
    public Vector3 ViewAngles { get; private set; }
    public Vector3 AimPunchAngle { get; private set; }
    public int AimPunchCacheCount { get; private set; }
    public Vector3 AimDirection { get; private set; }
    public Vector3 EyeDirection { get; private set; }
    public static int Fov => 90;
    public int FFlags { get; private set; }

    private int PreviousTotalHits { get; set; }

    protected override IntPtr ReadControllerBase(GameProcess gameProcess)
    {
        if (gameProcess.ModuleClient == null)
            throw new ArgumentNullException(nameof(gameProcess.ModuleClient), "ModuleClient cannot be null.");
        return gameProcess.ModuleClient.Read<IntPtr>(Offsets.dwLocalPlayerController);
    }

    protected override IntPtr ReadAddressBase(GameProcess gameProcess)
    {
        if (gameProcess.ModuleClient == null)
            throw new ArgumentNullException(nameof(gameProcess.ModuleClient), "ModuleClient cannot be null.");
        return gameProcess.ModuleClient.Read<IntPtr>(Offsets.dwLocalPlayerPawn);
    }

    public override bool Update(GameProcess gameProcess)
    {
        if (!base.Update(gameProcess)) return false;


        if (gameProcess.ModuleClient == null)
            throw new ArgumentNullException(nameof(gameProcess.ModuleClient), "ModuleClient cannot be null.");
        MatrixViewProjection = Matrix4x4.Transpose(gameProcess.ModuleClient.Read<Matrix4x4>(Offsets.dwViewMatrix));
        MatrixViewport = Utility.GetMatrixViewport(gameProcess.WindowRectangleClient.Size);
        MatrixViewProjectionViewport = MatrixViewProjection * MatrixViewport;

        if (gameProcess.Process == null)
            throw new ArgumentNullException(nameof(gameProcess.Process), "Process cannot be null.");

        ViewOffset = gameProcess.Process.Read<Vector3>(AddressBase + Offsets.m_vecViewOffset);
        EyePosition = Origin + ViewOffset;
        ViewAngles = gameProcess.ModuleClient.Read<Vector3>(Offsets.dwViewAngles);
        AimPunchAngle = ReadAimPunchAngle(gameProcess);
        FFlags = gameProcess.Process.Read<int>(AddressBase + Offsets.m_fFlags);

        EyeDirection =
            GraphicsMath.GetVectorFromEulerAngles(ViewAngles.X.DegreeToRadian(), ViewAngles.Y.DegreeToRadian());
        AimDirection = GraphicsMath.GetVectorFromEulerAngles
        (
            (ViewAngles.X + AimPunchAngle.X * Offsets.WeaponRecoilScale).DegreeToRadian(),
            (ViewAngles.Y + AimPunchAngle.Y * Offsets.WeaponRecoilScale).DegreeToRadian()
        );


        try
        {
            var totalHits = gameProcess.Process.Read<int>
            (
                gameProcess.Process.Read<IntPtr>(AddressBase + 0x1518) + 0x40
            );

            if (totalHits != PreviousTotalHits && totalHits > 0)
            {
                using var player = new SoundPlayer("hit.wav");
                player.Play();
            }

            PreviousTotalHits = totalHits;
        }
        catch (Exception)
        {
        }


        return true;
    }

    private Vector3 ReadAimPunchAngle(GameProcess gameProcess)
    {
        if (gameProcess.Process == null)
            throw new ArgumentNullException(nameof(gameProcess.Process), "Process cannot be null.");

        var aimPunchService = gameProcess.Process.Read<IntPtr>(AddressBase + Offsets.m_pAimPunchServices);
        if (aimPunchService != IntPtr.Zero)
        {
            try
            {
                return gameProcess.Process.Read<Vector3>(aimPunchService + Offsets.m_vecCsViewPunchAngle);
            }
            catch (Exception)
            {
                // Fall back to legacy path if the service access fails
            }
        }

        var cacheAddress = AddressBase + Offsets.m_AimPunchCache;
        AimPunchCacheCount = gameProcess.Process.Read<int>(cacheAddress);
        var cacheData = gameProcess.Process.Read<IntPtr>(cacheAddress + 0x8);

        if (AimPunchCacheCount > 0 && AimPunchCacheCount < 128 && cacheData != IntPtr.Zero)
            return gameProcess.Process.Read<Vector3>(cacheData + (AimPunchCacheCount - 1) * 12);

        AimPunchCacheCount = gameProcess.Process.Read<int>(cacheAddress + 0x8);
        cacheData = gameProcess.Process.Read<IntPtr>(cacheAddress + 0x10);

        if (AimPunchCacheCount > 0 && AimPunchCacheCount < 128 && cacheData != IntPtr.Zero)
            return gameProcess.Process.Read<Vector3>(cacheData + (AimPunchCacheCount - 1) * 12);

        return gameProcess.Process.Read<Vector3>(AddressBase + Offsets.m_AimPunchAngle);
    }

    private static readonly HashSet<string> GrenadeNames = new()
    {
        nameof(WeaponIndexes.Smokegrenade),
        nameof(WeaponIndexes.Flashbang),
        nameof(WeaponIndexes.Hegrenade),
        nameof(WeaponIndexes.Molotov)
    };

    public bool IsGrenade()
    {
        return GrenadeNames.Contains(CurrentWeaponName);
    }
}