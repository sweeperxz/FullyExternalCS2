using CS2Cheat.Core.Data;
using CS2Cheat.Data.Entity;
using CS2Cheat.Graphics;
using SharpDX;
using SharpDX.Direct3D9;
using Color = SharpDX.Color;

namespace CS2Cheat.Features;

public static class EspBox
{
    private const int OutlineThickness = 2;

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

    public static void Draw(Graphics.Graphics graphics)
    {
        var player = graphics.GameData.Player;
        if (player == null || graphics.GameData.Entities == null)
        {
            return;
        }

        foreach (var entity in graphics.GameData.Entities)
            {
            if (!entity.IsAlive() || entity.AddressBase == player.AddressBase)
            {
                continue;
            }

                var boundingBox = GetEntityBoundingBox(graphics, entity);
                if (boundingBox == null)
                {
                    continue;
                }

                var colorBox = entity.Team == Team.Terrorists ? Color.DarkRed : Color.DarkBlue;
                DrawEntityInfo(graphics, entity, colorBox, boundingBox.Value);
            }
    }

    private static void DrawEntityInfo(Graphics.Graphics graphics, Entity entity, Color color, (Vector2, Vector2) boundingBox)
    {
        var (topLeft, bottomRight) = boundingBox;
        if (topLeft.X > bottomRight.X || topLeft.Y > bottomRight.Y)
        {
            return;
        }

        float healthPercentage = Math.Clamp(entity.Health / 100f, 0f, 1f);

        graphics.DrawRectangle(color, topLeft, bottomRight);

        // Health bar
        var healthBarLeft = topLeft.X - 10f - OutlineThickness;
        var healthBarTopLeft = new Vector2(healthBarLeft, topLeft.Y);
        var healthBarBottomRight = new Vector2(healthBarLeft + 6f, bottomRight.Y);
        DrawHealthBar(graphics, healthBarTopLeft, healthBarBottomRight, healthPercentage);

        // Health number
        var healthText = entity.Health.ToString();
        var healthX = (int)(bottomRight.X + 2);
        int healthY = (int)(topLeft.Y + (bottomRight.Y - topLeft.Y) / 2);
        if (graphics.FontConsolas32 != null)
        {
            var healthTextSize = graphics.FontConsolas32.MeasureText(null, healthText, FontDrawFlags.Center);
            healthY = (int)(topLeft.Y + (bottomRight.Y - topLeft.Y - healthTextSize.Bottom) / 2);
            graphics.FontConsolas32.DrawText(default, healthText, healthX, healthY, Color.White);
        }

        // Weapon
        var weaponIcon = GetWeaponIcon(entity.CurrentWeaponName);
        if (!string.IsNullOrEmpty(weaponIcon) && graphics.Undefeated != null)
        {
            var textSize = graphics.Undefeated.MeasureText(null, weaponIcon, FontDrawFlags.Center);
            var weaponX = (int)((topLeft.X + bottomRight.X - textSize.Right) / 2);
            var weaponY = (int)(bottomRight.Y + 2.5f);
            graphics.Undefeated.DrawText(null, weaponIcon, weaponX, weaponY, Color.White);
        }

        // Enemy name
        if (graphics.GameData.Player != null && graphics.GameData.Player.Team != entity.Team)
        {
            var name = entity.Name ?? "UNKNOWN";
            var textWidth = graphics.FontConsolas32.MeasureText(null, name, FontDrawFlags.Center).Right + 10f;
            var nameX = (int)((topLeft.X + bottomRight.X) / 2 - textWidth / 2);
            var nameY = (int)(topLeft.Y - 15f);
            graphics.FontConsolas32.DrawText(default, name, nameX, nameY, Color.White);
        }

        // Status flags
        var flagX = (int)(bottomRight.X + 5f);
        var flagY = (int)topLeft.Y;
        var spacing = 15;

        if (entity.IsInScope == 1)
            graphics.FontConsolas32.DrawText(default, "Scoped", flagX, flagY, Color.White);

        if (entity.FlashAlpha > 7)
            graphics.FontConsolas32.DrawText(default, "Flashed", flagX, flagY + spacing, Color.White);

        if (entity.IsInScope == 256)
            graphics.FontConsolas32.DrawText(default, "Shifting", flagX, flagY + spacing * 2, Color.White);
        else if (entity.IsInScope == 257)
            graphics.FontConsolas32.DrawText(default, "Shifting in scope", flagX, flagY + spacing * 3, Color.White);
    }

    private static void DrawHealthBar(Graphics.Graphics graphics, Vector2 topLeft, Vector2 bottomRight, float healthPercentage)
    {
        var filledHeight = (bottomRight.Y - topLeft.Y) * healthPercentage;
        var filledTop = new Vector2(topLeft.X, Math.Max(bottomRight.Y - filledHeight, topLeft.Y));

        graphics.DrawRectangle(Color.Green, filledTop, bottomRight);
        graphics.DrawRectangle(Color.Black,
            new Vector2(topLeft.X - OutlineThickness, filledTop.Y - OutlineThickness),
            new Vector2(bottomRight.X + OutlineThickness, bottomRight.Y + OutlineThickness));
    }

    private static string GetWeaponIcon(string weapon) =>
        GunIcons.TryGetValue(weapon?.ToLower() ?? string.Empty, out var icon) ? icon : string.Empty;

    private static (Vector2, Vector2)? GetEntityBoundingBox(Graphics.Graphics graphics, Entity entity)
    {
        const float padding = 5.0f;
        var minPos = new Vector2(float.MaxValue, float.MaxValue);
        var maxPos = new Vector2(float.MinValue, float.MinValue);

        var matrix = graphics.GameData.Player?.MatrixViewProjectionViewport;
        if (matrix == null || entity.BonePos == null || entity.BonePos.Count == 0)
        {
            return null;
        }

        bool anyValid = false;
        foreach (var bone in entity.BonePos.Values)
        {
            var transformed = GraphicsMath.Transform(matrix.Value, bone);
            if (transformed.Z >= 1 || transformed.X < 0 || transformed.Y < 0)
            {
                continue;
            }

            anyValid = true;
            minPos.X = Math.Min(minPos.X, transformed.X);
            minPos.Y = Math.Min(minPos.Y, transformed.Y);
            maxPos.X = Math.Max(maxPos.X, transformed.X);
            maxPos.Y = Math.Max(maxPos.Y, transformed.Y);
        }


        if (!anyValid)
        {
            return null;
        }

        var sizeMultiplier = 2f - entity.Health / 100f;
        var paddingVector = new Vector2(padding * sizeMultiplier);
        return (minPos - paddingVector, maxPos + paddingVector);
    }
}
