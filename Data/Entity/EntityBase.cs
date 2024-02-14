using CS2Cheat.Core.Data;
using CS2Cheat.Data.Game;
using CS2Cheat.Utils;
using SharpDX;

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

    private short WeaponIndex { get; set; }


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
        EntityList = gameProcess.ModuleClient.Read<IntPtr>(Offsets.dwEntityList);
        ControllerBase = ReadControllerBase(gameProcess);
        AddressBase = ReadAddressBase(gameProcess);
        if (ControllerBase == IntPtr.Zero || AddressBase == IntPtr.Zero) return false;


        LifeState = gameProcess.Process.Read<bool>(AddressBase + Offsets.m_lifeState);
        Health = gameProcess.Process.Read<int>(AddressBase + Offsets.m_iHealth);
        Team = gameProcess.Process.Read<int>(AddressBase + Offsets.m_iTeamNum).ToTeam();
        Origin = gameProcess.Process.Read<Vector3>(AddressBase + Offsets.m_vOldOrigin);
        ShotsFired = gameProcess.Process.Read<int>(AddressBase + Offsets.m_iShotsFired);

        CurrentWeapon = gameProcess.Process.Read<IntPtr>(AddressBase + Offsets.m_pClippingWeapon);
        WeaponIndex = gameProcess.Process.Read<short>(CurrentWeapon + Offsets.m_AttributeManager + Offsets.m_Item +
                                                      Offsets.m_iItemDefinitionIndex);
        CurrentWeaponName = Enum.GetName(typeof(WeaponIndexes), WeaponIndex)!;

        return true;
    }
}