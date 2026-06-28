using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Keys = Process.NET.Native.Types.Keys;

namespace CS2Cheat.Utils;

public class ConfigManager
{
    private const string ConfigFile = "config.json";

    private static ConfigManager? _cachedInstance;
    private static readonly object _cacheLock = new();
    private static FileSystemWatcher? _watcher;

    public bool EspBox { get; set; }
    public bool EspName { get; set; }
    public bool EspWeapon { get; set; }
    public bool EspFlags { get; set; }
    public float[] EspBoxColor { get; set; } = new float[] { 1f, 0f, 0f, 1f };
    public bool SkeletonEsp { get; set; }
    public bool EspAimCrosshair { get; set; }
    public bool BombTimer { get; set; }
    public bool VoteTeller { get; set; }
    public bool TeamCheck { get; set; }

    public bool AimBot { get; set; }
    public bool AimFovCircle { get; set; }
    public float AimFov { get; set; }
    public float AimSmoothing { get; set; }
    public int AimBoneIndex { get; set; }
    public bool AimRcs { get; set; }
    public float AimRcsStrength { get; set; }

    public bool TriggerBot { get; set; }

    [JsonConverter(typeof(KeysJsonConverter))]
    public Keys AimBotKey { get; set; }

    [JsonConverter(typeof(KeysJsonConverter))]
    public Keys AimRcsKey { get; set; }

    [JsonConverter(typeof(KeysJsonConverter))]
    public Keys TriggerBotKey { get; set; }

    [JsonConverter(typeof(KeysJsonConverter))]
    public Keys MenuToggleKey { get; set; }

    [JsonIgnore]
    public static readonly string[] BoneNames = { "head", "neck_0", "spine_1", "pelvis" };

    [JsonIgnore]
    public static readonly string[] BoneDisplayNames = { "Head", "Neck", "Chest", "Pelvis" };


    public static ConfigManager Load()
    {
        lock (_cacheLock)
        {
            if (_cachedInstance != null)
            {
                return _cachedInstance;
            }

            _cachedInstance = LoadFromDisk();
            InitializeWatcher();
            return _cachedInstance;
        }
    }

    public static void Reload()
    {
        lock (_cacheLock)
        {
            _cachedInstance = LoadFromDisk();
            Console.WriteLine("[INFO] Config reloaded.");
        }
    }

    public static void UpdateCache(ConfigManager config)
    {
        lock (_cacheLock)
        {
            _cachedInstance = config;
        }
    }

    private static ConfigManager LoadFromDisk()
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
            var result = options ?? Default();
            ApplyMissingDefaults(result, json);
            SanitizeKeys(result);
            return result;
        }
        catch (JsonException)
        {
            return Default();
        }
        catch (IOException)
        {
            return _cachedInstance ?? Default();
        }
    }

    private static void ApplyMissingDefaults(ConfigManager config, string json)
    {
        var defaults = Default();
        if (!json.Contains(nameof(EspName), StringComparison.OrdinalIgnoreCase))
        {
            config.EspName = defaults.EspName;
        }
        if (!json.Contains(nameof(EspWeapon), StringComparison.OrdinalIgnoreCase))
        {
            config.EspWeapon = defaults.EspWeapon;
        }
        if (!json.Contains(nameof(EspFlags), StringComparison.OrdinalIgnoreCase))
        {
            config.EspFlags = defaults.EspFlags;
        }
        if (!json.Contains(nameof(VoteTeller), StringComparison.OrdinalIgnoreCase))
        {
            config.VoteTeller = defaults.VoteTeller;
        }
    }

    private static void SanitizeKeys(ConfigManager config)
    {
        var defaults = Default();
        if (config.MenuToggleKey == Keys.None)
        {
            config.MenuToggleKey = defaults.MenuToggleKey;
        }
        if (config.AimBotKey == Keys.None)
        {
            config.AimBotKey = defaults.AimBotKey;
        }
        if (config.AimRcsKey == Keys.None)
        {
            config.AimRcsKey = defaults.AimRcsKey;
        }
        if (config.TriggerBotKey == Keys.None)
        {
            config.TriggerBotKey = defaults.TriggerBotKey;
        }
        if (config.AimFov <= 0)
        {
            config.AimFov = defaults.AimFov;
        }
        if (config.AimSmoothing <= 0)
        {
            config.AimSmoothing = defaults.AimSmoothing;
        }
    }

    private static void InitializeWatcher()
    {
        if (_watcher != null)
        {
            return;
        }

        try
        {
            var directory = Path.GetDirectoryName(Path.GetFullPath(ConfigFile)) ?? ".";
            var fileName = Path.GetFileName(ConfigFile);

            _watcher = new FileSystemWatcher(directory, fileName)
            {
                NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size,
                EnableRaisingEvents = true
            };

            _watcher.Changed += (_, _) =>
            {
                Thread.Sleep(100);
                Reload();
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[WARN] Could not initialize config watcher: {ex.Message}");
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
            UpdateCache(options);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Failed to save config: {ex.Message}");
        }
    }

    public static ConfigManager Default()
    {
        return new ConfigManager
        {
            AimBot = true,
            AimFovCircle = true,
            AimFov = 15f,
            AimSmoothing = 3f,
            AimBoneIndex = 0,
            AimRcs = true,
            AimRcsStrength = 100f,
            BombTimer = true,
            VoteTeller = true,
            EspAimCrosshair = false,
            EspBox = true,
            EspName = true,
            EspWeapon = true,
            EspFlags = true,
            EspBoxColor = new float[] { 1f, 0f, 0f, 1f },
            SkeletonEsp = false,
            TriggerBot = true,
            AimBotKey = Keys.LButton,
            AimRcsKey = Keys.LButton,
            TriggerBotKey = Keys.LMenu,
            MenuToggleKey = Keys.Insert,
            TeamCheck = true
        };
    }

    public static string GetKeyName(Keys key)
    {
        return key switch
        {
            Keys.LButton => "LMB",
            Keys.RButton => "RMB",
            Keys.MButton => "MMB",
            Keys.XButton1 => "Mouse4",
            Keys.XButton2 => "Mouse5",
            Keys.LMenu => "LAlt",
            Keys.RMenu => "RAlt",
            Keys.LShiftKey => "LShift",
            Keys.RShiftKey => "RShift",
            Keys.LControlKey => "LCtrl",
            Keys.RControlKey => "RCtrl",
            Keys.Insert => "Insert",
            Keys.Delete => "Delete",
            Keys.Home => "Home",
            Keys.End => "End",
            Keys.Capital => "CapsLock",
            _ => key.ToString()
        };
    }
}

public class KeysJsonConverter : JsonConverter<Keys>
{
    public override Keys Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var str = reader.GetString();
            if (Enum.TryParse<Keys>(str, true, out var result))
                return result;
        }
        else if (reader.TokenType == JsonTokenType.Number)
        {
            return (Keys)reader.GetInt32();
        }

        return Keys.None;
    }

    public override void Write(Utf8JsonWriter writer, Keys value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
