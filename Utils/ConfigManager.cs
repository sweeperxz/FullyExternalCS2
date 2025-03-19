using System.IO;
using System.Text.Json;

namespace CS2Cheat.Utils;

public class ConfigManager
{
    public bool AimBot { get; set; }
    public bool BombTimer { get; set; }
    public bool EspAimCrosshair { get; set; }
    public bool EspBox { get; set; }
    public bool SkeletonEsp { get; set; }
    public bool TriggerBot { get; set; }

    private const string ConfigFile = "config.json";

    public static ConfigManager Load()
    {
        try
        {
            if (!File.Exists(ConfigFile))
            {
                var defaultOptions = Default();
                Save(defaultOptions);
                return defaultOptions;
            }

            var json = File.ReadAllText(ConfigFile);
            var options = JsonSerializer.Deserialize<ConfigManager>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return options ?? Default();
        }
        catch (JsonException)
        {
            return Default();
        }
    }

    public static void Save(ConfigManager options)
    {
        try
        {
            var json = JsonSerializer.Serialize(options, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(ConfigFile, json);
        }
        catch (JsonException)
        {
            // Handle serialization errors
        }
    }

    public static ConfigManager Default()
    {
        return new ConfigManager
        {
            AimBot = true,
            BombTimer = true,
            EspAimCrosshair = true,
            EspBox = true,
            SkeletonEsp = true,
            TriggerBot = true
        };
    }
}