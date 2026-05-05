using System.Numerics;
using CS2Cheat.Core.Data;
using CS2Cheat.Data.Entity;
using CS2Cheat.Data.Game;
using CS2Cheat.Graphics;
using CS2Cheat.Utils;
using ImGuiNET;

namespace CS2Cheat.Features;

public static class EspBox
{
    private static readonly Dictionary<string, string> GunIcons = new()
    {
        ["knife_ct"] = "]", ["knife_t"] = "[", ["deagle"] = "A", ["elite"] = "B",
        ["fiveseven"] = "C", ["glock"] = "D", ["revolver"] = "J", ["hkp2000"] = "E",
        ["p250"] = "F", ["usp_silencer"] = "G", ["tec9"] = "H", ["cz75a"] = "I",
        ["mac10"] = "K", ["ump45"] = "L", ["bizon"] = "M", ["mp7"] = "N",
        ["mp9"] = "R", ["p90"] = "O", ["galilar"] = "Q", ["famas"] = "R",
        ["m4a1_silencer"] = "T", ["m4a1"] = "S", ["aug"] = "U", ["sg556"] = "V",
        ["ak47"] = "W", ["g3sg1"] = "X", ["scar20"] = "Y", ["awp"] = "Z",
        ["ssg08"] = "a", ["xm1014"] = "b", ["sawedoff"] = "c", ["mag7"] = "d",
        ["nova"] = "e", ["negev"] = "f", ["m249"] = "g", ["taser"] = "h",
        ["flashbang"] = "i", ["hegrenade"] = "j", ["smokegrenade"] = "k",
        ["molotov"] = "l", ["decoy"] = "m", ["incgrenade"] = "n", ["c4"] = "o"
    };

    private static ConfigManager? _config;
    private static ConfigManager Config => _config ??= ConfigManager.Load();

    public static void Draw(ImDrawListPtr drawList, GameData gameData)
    {
        var player = gameData.Player;
        if (player == null || gameData.Entities == null) return;

        foreach (var entity in gameData.Entities)
        {
            if (!entity.IsAlive() || entity.AddressBase == player.AddressBase) continue;
            if (Config.TeamCheck && entity.Team == player.Team) continue;

            var boundingBox = GetEntityBoundingBox(player, entity);
            if (boundingBox == null) continue;

            var c = Config.EspBoxColor;
            var colorBox = OverlayRenderer.ToColor(new Vector4(c[0], c[1], c[2], c[3]));
            DrawEntityInfo(drawList, player, entity, colorBox, boundingBox.Value);
        }
    }

    private static void DrawEntityInfo(ImDrawListPtr drawList, Player player, Entity entity, uint color,
        (Vector2, Vector2) boundingBox)
    {
        var (topLeft, bottomRight) = boundingBox;
        if (topLeft.X > bottomRight.X || topLeft.Y > bottomRight.Y) return;

        var healthPercentage = Math.Clamp(entity.Health / 100f, 0f, 1f);

        drawList.AddRect(topLeft, bottomRight, color, 0, ImDrawFlags.None, 1.5f);

        var healthBarLeft = topLeft.X - 10f;
        var healthBarTopLeft = new Vector2(healthBarLeft, topLeft.Y);
        var healthBarBottomRight = new Vector2(healthBarLeft + 6f, bottomRight.Y);
        DrawHealthBar(drawList, healthBarTopLeft, healthBarBottomRight, healthPercentage);

        var healthText = entity.Health.ToString();
        var healthX = bottomRight.X + 4;
        var healthY = topLeft.Y + (bottomRight.Y - topLeft.Y) / 2 - 6;
        drawList.AddText(new Vector2(healthX, healthY), OverlayRenderer.Colors.White, healthText);

        if (Config.EspWeapon)
        {
            var weaponName = FormatWeaponName(entity);
            if (!string.IsNullOrEmpty(weaponName))
            {
                var weaponX = (topLeft.X + bottomRight.X) / 2 - weaponName.Length * 3.5f;
                var weaponY = bottomRight.Y + 4;
                DrawOutlinedText(drawList, new Vector2(weaponX, weaponY), OverlayRenderer.Colors.White, weaponName);
            }
        }

        if (Config.EspName && player.Team != entity.Team)
        {
            var name = entity.Name ?? "UNKNOWN";
            var nameX = (topLeft.X + bottomRight.X) / 2 - name.Length * 3;
            var nameY = topLeft.Y - 15f;
            DrawOutlinedText(drawList, new Vector2(nameX, nameY), OverlayRenderer.Colors.White, name);
        }

        if (Config.EspFlags)
        {
            var flagX = bottomRight.X + 5f;
            var flagY = topLeft.Y;
            var spacing = 15;

            if (entity.IsInScope == 1)
                DrawOutlinedText(drawList, new Vector2(flagX, flagY), OverlayRenderer.Colors.White, "Scoped");

            if (entity.FlashAlpha > 7)
                DrawOutlinedText(drawList, new Vector2(flagX, flagY + spacing), OverlayRenderer.Colors.White, "Flashed");

            if (entity.IsInScope == 256)
                DrawOutlinedText(drawList, new Vector2(flagX, flagY + spacing * 2), OverlayRenderer.Colors.White, "Shifting");
            else if (entity.IsInScope == 257)
                DrawOutlinedText(drawList, new Vector2(flagX, flagY + spacing * 3), OverlayRenderer.Colors.White,
                    "Shifting in scope");
        }
    }

    private static void DrawHealthBar(ImDrawListPtr drawList, Vector2 topLeft, Vector2 bottomRight,
        float healthPercentage)
    {
        var totalHeight = bottomRight.Y - topLeft.Y;
        var filledHeight = totalHeight * healthPercentage;
        var filledTop = new Vector2(topLeft.X, Math.Max(bottomRight.Y - filledHeight, topLeft.Y));

        drawList.AddRectFilled(topLeft, bottomRight, OverlayRenderer.Colors.Black);

        var healthColor = GetHealthColor(healthPercentage);
        drawList.AddRectFilled(filledTop, bottomRight, healthColor);

        drawList.AddRect(topLeft, bottomRight, OverlayRenderer.Colors.DarkGray);
    }

    private static uint GetHealthColor(float percentage)
    {
        var r = (byte)(percentage < 0.5f ? 255 : (int)(255 * (1 - percentage) * 2));
        var g = (byte)(percentage > 0.5f ? 255 : (int)(255 * percentage * 2));
        return OverlayRenderer.ToColor(r, g, 0);
    }

    private static string GetWeaponIcon(string weapon)
    {
        return GunIcons.TryGetValue(weapon?.ToLower() ?? string.Empty, out var icon) ? icon : string.Empty;
    }

    private static string FormatWeaponName(Entity entity)
    {
        var weapon = entity.CurrentWeaponName;
        if (string.IsNullOrWhiteSpace(weapon)) return string.Empty;

        return weapon.Replace("Silencer", "-S", StringComparison.OrdinalIgnoreCase).ToUpperInvariant();
    }

    private static void DrawOutlinedText(ImDrawListPtr drawList, Vector2 position, uint color, string text)
    {
        drawList.AddText(position + new Vector2(1, 1), OverlayRenderer.Colors.Black, text);
        drawList.AddText(position, color, text);
    }

    private static (Vector2, Vector2)? GetEntityBoundingBox(Player player, Entity entity)
    {
        const float padding = 5.0f;
        var minPos = new Vector2(float.MaxValue, float.MaxValue);
        var maxPos = new Vector2(float.MinValue, float.MinValue);

        var matrix = player.MatrixViewProjectionViewport;
        if (entity.BonePos == null || entity.BonePos.Count == 0) return null;

        var anyValid = false;
        foreach (var bone in entity.BonePos.Values)
        {
            var transformed = matrix.Transform(bone);
            if (transformed.Z >= 1 || transformed.X < 0 || transformed.Y < 0) continue;

            anyValid = true;
            minPos.X = Math.Min(minPos.X, transformed.X);
            minPos.Y = Math.Min(minPos.Y, transformed.Y);
            maxPos.X = Math.Max(maxPos.X, transformed.X);
            maxPos.Y = Math.Max(maxPos.Y, transformed.Y);
        }

        if (!anyValid) return null;

        var paddingVector = new Vector2(padding);
        return (minPos - paddingVector, maxPos + paddingVector);
    }
}