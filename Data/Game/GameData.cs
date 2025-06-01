using CS2Cheat.Data.Entity;
using CS2Cheat.Utils;
using Microsoft.VisualBasic;

namespace CS2Cheat.Data.Game;

public class GameData : ThreadedServiceBase
{
    #region properties

    protected override string ThreadName => nameof(GameData);

    private GameProcess? GameProcess { get; set; }
    public Player? Player { get; private set; }
    public Entity.Entity? LocalEntity => Entities?.FirstOrDefault(e => e.AddressBase == Player?.AddressBase);
    public Entity.Entity[]? Entities { get; private set; }

    #endregion

    #region methods

    /// <inheritdoc />
    public GameData(GameProcess gameProcess)
    {
        GameProcess = gameProcess;
        Player = new Player();
        Entities = Enumerable.Range(0, 64).Select(index => new Entity.Entity(index)).ToArray();
    }

    public override void Dispose()
    {
        base.Dispose();

        Entities = null;
        Player = null;
        GameProcess = null;
    }

    protected override void FrameAction()
    {
        if (GameProcess == null || !GameProcess.IsValid)
        {
            return;
        }
        if (Player != null)
        {
            Player.Update(GameProcess);
        }

        if (Entities != null)
        {
            foreach (var entity in Entities) entity.Update(GameProcess);
        }
    }
    public bool IsBeingSpectated()
    {
        if (LocalEntity == null || Entities == null)
        {
            return false;
        }
        // Check if the local player is being spectated by another player
        foreach (var entity in Entities)
        {
            // Skip if the entity is null or if it is the local player
            if (entity == null || entity.AddressBase == LocalEntity.AddressBase)
            {
                continue;
            }

            if (entity.IsDead && entity.Team == LocalEntity.Team && !entity.IsDormant)
            {
                // If the entity is dead and on the same team, check if they are observing the local player
                if (entity.ObserverTarget == LocalEntity.ObserverTarget)
                {
                    Console.WriteLine($"Entity {entity.EntityIndex} is observing the local player.");
                    return true;
                }
            }
        }

        return false;
    }

    #endregion
}