using CS2Cheat.Utils;
using SharpDX;

namespace CS2Cheat.Data;

public abstract class EntityBase
{
    public IntPtr AddressBase { get; set; }
    
    public bool LifeState { get; set; }
    
    public int Health { get; set; }
    
    public Team Team { get; set; }
    
    public Vector3 Origin { get; set;}

    public virtual bool IsAlive()
    {
        return AddressBase != IntPtr.Zero &&
               !LifeState &&
               Health > 0 &&
               Team is Team.Terrorists or Team.CounterTerrorists;
    }
    
    protected abstract IntPtr ReadAddressBase(GameProcess gameProcess);

    public virtual bool Update(GameProcess gameProcess)
    {
        AddressBase = ReadAddressBase(gameProcess);
        if (AddressBase == IntPtr.Zero)
        {
            return false;
        }

        LifeState = gameProcess.Process.Read<bool>(AddressBase + Offsets.m_lifeState);
        Health = gameProcess.Process.Read<int>(AddressBase + Offsets.m_iHealth);
        Team = gameProcess.Process.Read<int>(AddressBase + Offsets.m_iTeamNum).ToTeam();
        Origin = gameProcess.Process.Read<Vector3>(AddressBase + Offsets.m_vOldOrigin);

        return true;
    }
}