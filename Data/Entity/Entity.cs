using CS2Cheat.Data.Game;
using CS2Cheat.Utils;
using SharpDX;
using System.Collections.Concurrent;

namespace CS2Cheat.Data.Entity;

public class Entity : EntityBase
{
    private readonly int _index;
    private bool _dormant = true;
    private readonly ConcurrentDictionary<string, Vector3> _bonePositions;

    public Entity(int index)
    {
        _index = index;
        _bonePositions = new ConcurrentDictionary<string, Vector3>(Offsets.Bones.ToDictionary(
            bone => bone.Key,
            _ => Vector3.Zero
        ));
    }

    public int EntityIndex => _index;
    public int ObserverTarget { get; private set; }
    public bool IsDormant => _dormant;
    public bool IsDead => !IsAlive();  // Valid for spectate checks

    protected internal bool IsSpotted { get; private set; }
    protected internal string Name { get; private set; } = string.Empty;
    protected internal int IsInScope { get; private set; }
    protected internal int FlashAlpha { get; private set; }
    public IReadOnlyDictionary<string, Vector3> BonePos => _bonePositions;

    public override bool IsAlive() => base.IsAlive() && !_dormant;

    protected override IntPtr ReadControllerBase(GameProcess gameProcess)
    {
        var entryIndex = (_index & 0x7FFF) >> 9;

        if (gameProcess?.Process == null)
        {
            return IntPtr.Zero;
        }

        var listEntry = gameProcess.Process.Read<IntPtr>(EntityList + (8 * entryIndex) + 16);

        return listEntry != IntPtr.Zero 
            ? gameProcess.Process.Read<IntPtr>(listEntry + 120 * (_index & 0x1FF)) 
            : IntPtr.Zero;
    }

    protected override IntPtr ReadAddressBase(GameProcess gameProcess)
    {
        if (gameProcess?.Process == null)
        {
            return IntPtr.Zero;
        }

        var playerPawn = gameProcess.Process.Read<int>(ControllerBase + Offsets.m_hPawn);
        var pawnIndex = (playerPawn & 0x7FFF) >> 9;
        var listEntry = gameProcess.Process.Read<IntPtr>(EntityList + 0x8 * pawnIndex + 16);

        return listEntry != IntPtr.Zero 
            ? gameProcess.Process.Read<IntPtr>(listEntry + 120 * (playerPawn & 0x1FF)) 
            : IntPtr.Zero;
    }

    public override bool Update(GameProcess gameProcess)
    {
        if (!base.Update(gameProcess)) return false;

        if (gameProcess?.Process == null)
        {
            return false;
        }

        _dormant = gameProcess.Process.Read<bool>(AddressBase + Offsets.m_bDormant);
        IsSpotted = gameProcess.Process.Read<bool>(AddressBase + Offsets.m_entitySpottedState + 0x8);
        IsInScope = gameProcess.Process.Read<int>(AddressBase + Offsets.m_bIsScoped);
        FlashAlpha = gameProcess.Process.Read<int>(AddressBase + Offsets.m_flFlashDuration);
        Name = gameProcess.Process.ReadString(ControllerBase + Offsets.m_iszPlayerName);
        

        // ✅ Read spectator-related field
        ObserverTarget = gameProcess.Process.Read<int>(AddressBase + Offsets.m_hObserverTarget);

        return !IsAlive() || UpdateBonePositions(gameProcess);
    }

    private bool UpdateBonePositions(GameProcess gameProcess)
    {
        try
        {
            if (gameProcess?.Process == null)
            {
                return false;
            }

            var gameSceneNode = gameProcess.Process.Read<IntPtr>(AddressBase + Offsets.m_pGameSceneNode);
            var boneArray = gameProcess.Process.Read<IntPtr>(gameSceneNode + Offsets.m_modelState + 128);

            foreach (var (boneName, boneIndex) in Offsets.Bones)
            {
                var bonePos = gameProcess.Process.Read<Vector3>(boneArray + boneIndex * 32);
                _bonePositions.AddOrUpdate(boneName, bonePos, (_, _) => bonePos);
            }

            return true;
        }
        catch
        {
            return false;
        }
    }
}
