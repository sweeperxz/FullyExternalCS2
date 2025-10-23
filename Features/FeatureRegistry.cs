using System;
using CS2Cheat.Data.Game;
using CS2Cheat.Utils;

namespace CS2Cheat.Features;

public static class FeatureRegistry
{
    public static void Register(ServiceRegistry registry, GameProcess gameProcess, GameData gameData,
        Graphics.Graphics graphics)
    {
        if (registry == null) throw new ArgumentNullException(nameof(registry));
        if (gameProcess == null) throw new ArgumentNullException(nameof(gameProcess));
        if (gameData == null) throw new ArgumentNullException(nameof(gameData));
        if (graphics == null) throw new ArgumentNullException(nameof(graphics));

        registry.Register(nameof(TriggerBot), new TriggerBot(gameProcess, gameData), config => config.TriggerBot);
        registry.Register(nameof(AimBot), new AimBot(gameProcess, gameData), config => config.AimBot);
        registry.Register(nameof(BombTimer), new BombTimer(graphics), config => config.BombTimer);
    }
}
