using CS2Cheat.Core.Data;
using CS2Cheat.Data.Game;
using CS2Cheat.Utils;
using System.Numerics;

namespace CS2Cheat.Data.Entity;

public abstract class EntityBase
{
    protected IntPtr EntityList { get; private set; }
    protected IntPtr ControllerBase { get; private set; }
    public IntPtr AddressBase { get; private set; }

    private bool LifeState { get; set; }
    public int Health { get; private set; }
    public Team Team { get; private set; }
    protected Vector3 Origin { get; private set; }
    public int ShotsFired { get; private set; }

    private IntPtr CurrentWeapon { get; set; }
    public string CurrentWeaponName { get; private set; } = null!;

    public short WeaponIndex { get; private set; }

    public Vector3 Velocity { get; private set; }


    public virtual bool IsAlive()
    {
        return ControllerBase != IntPtr.Zero &&
               AddressBase != IntPtr.Zero &&
               LifeState &&
               Health > 0 &&
               Team is Team.Terrorists or Team.CounterTerrorists;
    }

    protected abstract IntPtr ReadControllerBase(GameProcess gameProcess);
    protected abstract IntPtr ReadAddressBase(GameProcess gameProcess);

    public virtual bool Update(GameProcess gameProcess)
    {
        if (gameProcess.ModuleClient == null)
            throw new ArgumentNullException(nameof(gameProcess.ModuleClient), "ModuleClient cannot be null.");
        EntityList = gameProcess.ModuleClient.Read<IntPtr>(Offsets.dwEntityList);
        ControllerBase = ReadControllerBase(gameProcess);
        AddressBase = ReadAddressBase(gameProcess);
        if (ControllerBase == IntPtr.Zero || AddressBase == IntPtr.Zero) return false;

        if (gameProcess.Process == null)
            throw new ArgumentNullException(nameof(gameProcess.Process), "Process cannot be null.");

        LifeState = gameProcess.Process.Read<bool>(AddressBase + Offsets.m_lifeState);
        Health = gameProcess.Process.Read<int>(AddressBase + Offsets.m_iHealth);
        Team = gameProcess.Process.Read<int>(AddressBase + Offsets.m_iTeamNum).ToTeam();
        Origin = gameProcess.Process.Read<Vector3>(AddressBase + Offsets.m_vOldOrigin);
        ShotsFired = gameProcess.Process.Read<int>(AddressBase + Offsets.m_iShotsFired);

        CurrentWeapon = ReadCurrentWeapon(gameProcess);
        WeaponIndex = CurrentWeapon == IntPtr.Zero
            ? (short)0
            : gameProcess.Process.Read<short>(CurrentWeapon + Offsets.m_AttributeManager + Offsets.m_Item +
                                              Offsets.m_iItemDefinitionIndex);
        CurrentWeaponName = Enum.GetName(typeof(WeaponIndexes), WeaponIndex) ?? string.Empty;
        Velocity = gameProcess.Process.Read<Vector3>(AddressBase + Offsets.m_vecAbsVelocity);

        return true;
    }

    private IntPtr ReadCurrentWeapon(GameProcess gameProcess)
    {
        if (gameProcess.Process == null) return IntPtr.Zero;

        var directWeapon = gameProcess.Process.Read<IntPtr>(AddressBase + Offsets.m_pClippingWeapon);
        if (IsValidWeaponIndex(gameProcess, directWeapon)) return directWeapon;

        var weaponHandle = gameProcess.Process.Read<int>(AddressBase + Offsets.m_pClippingWeapon);
        var weaponFromHandle = ReadEntityFromHandle(gameProcess, weaponHandle);
        return IsValidWeaponIndex(gameProcess, weaponFromHandle) ? weaponFromHandle : IntPtr.Zero;
    }

    private bool IsValidWeaponIndex(GameProcess gameProcess, IntPtr weaponAddress)
    {
        if (gameProcess.Process == null || weaponAddress == IntPtr.Zero) return false;

        var weaponIndex = gameProcess.Process.Read<short>(weaponAddress + Offsets.m_AttributeManager + Offsets.m_Item +
                                                          Offsets.m_iItemDefinitionIndex);
        return Enum.IsDefined(typeof(WeaponIndexes), (int)weaponIndex);
    }

    private IntPtr ReadEntityFromHandle(GameProcess gameProcess, int handle)
    {
        if (gameProcess.Process == null || handle <= 0) return IntPtr.Zero;

        var entry = gameProcess.Process.Read<IntPtr>(EntityList + 0x8 * ((handle & 0x7FFF) >> 9) + 16);
        return entry == IntPtr.Zero
            ? IntPtr.Zero
            : gameProcess.Process.Read<IntPtr>(entry + 112 * (handle & 0x1FF));
    }
}