using CS2Cheat.Utils;
using SharpDX;

namespace CS2Cheat.Data;

public abstract class EntityBase
{
    public IntPtr EntityList { get; protected set; }
    public IntPtr ControllerBase { get; protected set; }
    public IntPtr AddressBase { get; protected set; }

    public bool LifeState { get; protected set; }
    public int Health { get; protected set; }
    public int Armor { get; protected set; }
    public Team Team { get; protected set; }
    public Vector3 Origin { get; private set; }
    public int ShotsFired { get; private set; }

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

        return true;
    }
}