using CS2Cheat.Utils;

namespace CS2Cheat.Data;

public class Entity(int index) : EntityBase
{
    private int Index { get; } = index;
    public bool Dormant { get; private set; }

    public override bool IsAlive()
    {
        return base.IsAlive();
    }

    protected override IntPtr ReadAddressBase(GameProcess gameProcess)
    {
        var currentpawn = new List<IntPtr>(64);
        var entityList = gameProcess.ModuleClient.Read<IntPtr>(Offsets.dwEntityList);
        var listEntryFirst = gameProcess.Process.Read<IntPtr>(entityList + 0x10);
        for (var i = 0; i < 64; i++)
        {
            if (listEntryFirst == IntPtr.Zero) continue;

            var currentController = gameProcess.Process.Read<IntPtr>(listEntryFirst + i * 0x78);
            if (currentController == IntPtr.Zero) continue;

            var pawnHandle = gameProcess.Process.Read<int>(currentController + Offsets.m_hPlayerPawn);
            if (pawnHandle is 0) continue;

            var listEntrySecond =
                gameProcess.Process.Read<IntPtr>(entityList + 0x8 * ((pawnHandle & 0x7FFF) >> 9) + 0x10);
            currentpawn.Add(gameProcess.Process.Read<IntPtr>(listEntrySecond + 0x78 * (pawnHandle & 0x1FF)));
        }

        if (index >= 0 && index < currentpawn.Count)
        {
            return currentpawn[index];
        }
        return IntPtr.Zero;
    }


    public override bool Update(GameProcess gameProcess)
    {
        if (!base.Update(gameProcess)) return false;

        Dormant = gameProcess.Process.Read<bool>(AddressBase + Offsets.m_bDormant);
        return !IsAlive() || true;
    }
}