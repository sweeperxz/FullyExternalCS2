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

    public static void Draw(Graphics.Graphics graphics)
    {
        var boundingBoxes = new Dictionary<Entity, (Vector2, Vector2)>();

        foreach (var entity in graphics.GameData.Entities)
        {
            if (!entity.IsAlive() || entity.AddressBase == graphics.GameData.Player.AddressBase)
                continue;

            var boundingBox = GetEntityBoundingBox(graphics, entity);
            boundingBoxes.Add(entity, boundingBox);
        }

        foreach (var entity in boundingBoxes.Keys)
        {
            var colorBox = entity.Team == Team.Terrorists ? Color.DarkRed : Color.DarkBlue;
            DrawEntityRectangle(graphics, entity, colorBox, boundingBoxes[entity]);
        }
    }

    private static void DrawEntityRectangle(Graphics.Graphics graphics, Entity entity, Color color,
        (Vector2, Vector2) boundingBox)
    {
        var healthPercentage = (float)entity.Health / 100;

        graphics.DrawRectangle(color, boundingBox.Item1, boundingBox.Item2);

        var healthBarTopLeft = new Vector2(boundingBox.Item1.X - 10.0f - OutlineThickness, boundingBox.Item1.Y);
        var healthBarBottomRight = new Vector2(healthBarTopLeft.X + 6.0f, boundingBox.Item2.Y); 
        DrawHealthBar(graphics, healthBarTopLeft, healthBarBottomRight, healthPercentage);

        DrawHealthNumber(graphics, boundingBox.Item1, boundingBox.Item2, entity.Health);

        DrawWeaponName(graphics, boundingBox, entity.CurrentWeaponName);

        if (graphics.GameData.Player.Team != entity.Team)
            DrawEnemyName(graphics, boundingBox, entity.Name);

        DrawFlags(graphics, boundingBox, entity);
    }

    private static void DrawHealthBar(Graphics.Graphics graphics, Vector2 topLeft, Vector2 bottomRight,
        float healthPercentage)
    {
        var barHeight = bottomRight.Y - topLeft.Y;
        var filledHeight = barHeight * healthPercentage;
        var filledTopLeft = new Vector2(topLeft.X, bottomRight.Y - filledHeight);
        var filledBottomRight = bottomRight;

        filledTopLeft.Y = Math.Max(filledTopLeft.Y, topLeft.Y);
        filledBottomRight.Y = Math.Min(filledBottomRight.Y, bottomRight.Y);

        graphics.DrawRectangle(Color.Green, filledTopLeft, filledBottomRight);

        var outlineTopLeft =
            new Vector2(topLeft.X - OutlineThickness, filledTopLeft.Y - OutlineThickness); 
        var outlineBottomRight = new Vector2(bottomRight.X + OutlineThickness, bottomRight.Y + OutlineThickness);
        graphics.DrawRectangle(Color.Black, outlineTopLeft, outlineBottomRight);
    }

    private static void DrawWeaponName(Graphics.Graphics graphics, (Vector2, Vector2) boundingBox,
        string currentWeaponName)
    {
        var textWidth = graphics.FontConsolas32.MeasureText(null, currentWeaponName ?? "NONE", FontDrawFlags.Center)
            .Right + 30;
        var weaponNamePosition = new Vector2((boundingBox.Item1.X + boundingBox.Item2.X - textWidth) / 2,
            boundingBox.Item2.Y + 5f);
        graphics.FontConsolas32.DrawText(default, currentWeaponName ?? "NONE", (int)weaponNamePosition.X,
            (int)weaponNamePosition.Y, Color.White);
    }

    private static void DrawEnemyName(Graphics.Graphics graphics, (Vector2, Vector2) boundingBox, string enemyName)
    {
        var textWidth = graphics.FontConsolas32.MeasureText(null, enemyName ?? "UNKNOWN", FontDrawFlags.Center).Right +
                        10f;
        var enemyNamePosition = new Vector2((boundingBox.Item1.X + boundingBox.Item2.X) / 2 - textWidth / 2,
            boundingBox.Item1.Y - 15f);
        graphics.FontConsolas32.DrawText(default, enemyName ?? "UNKNOWN", (int)enemyNamePosition.X,
            (int)enemyNamePosition.Y, Color.White);
    }

    private static void DrawFlags(Graphics.Graphics graphics, (Vector2, Vector2) boundingBox, Entity entity)
    {
        var flagsPosition = new Vector2(boundingBox.Item2.X + 5f, boundingBox.Item1.Y);

        if (entity.IsinScope == 1)
            graphics.FontConsolas32.DrawText(default, "Scoped", (int)flagsPosition.X, (int)flagsPosition.Y,
                Color.White);

        if (entity.FlashAlpha > 7)
            graphics.FontConsolas32.DrawText(default, "Flashed", (int)flagsPosition.X, (int)flagsPosition.Y + 15,
                Color.White);

        switch (entity.IsinScope)
        {
            case 256:
                graphics.FontConsolas32.DrawText(default, "Shifting", (int)flagsPosition.X, (int)flagsPosition.Y + 30,
                    Color.White);
                break;
            case 257:
                graphics.FontConsolas32.DrawText(default, "Shifting in scope", (int)flagsPosition.X,
                    (int)flagsPosition.Y + 45, Color.White);
                break;
        }
    }

    private static void DrawHealthNumber(Graphics.Graphics graphics, Vector2 topLeft, Vector2 bottomRight, int health)
    {
        var healthText = health.ToString();
        var positionX = (int)(bottomRight.X + 2);
        var positionY = (int)(topLeft.Y + (bottomRight.Y - topLeft.Y) / 2 - graphics.FontConsolas32.MeasureText(null, healthText, FontDrawFlags.Center).Bottom / 2); 

        graphics.FontConsolas32.DrawText(default, healthText, positionX, positionY, Color.White);
    }

    private static (Vector2, Vector2) GetEntityBoundingBox(Graphics.Graphics graphics, Entity entity)
    {
        const float padding = 5.0f;
        var minScreenPos = new Vector2(float.MaxValue, float.MaxValue);
        var maxScreenPos = new Vector2(float.MinValue, float.MinValue);

        foreach (var transformedPos in entity.BonePos
                     .Select(bonePos => graphics.GameData.Player.MatrixViewProjectionViewport.Transform(bonePos.Value))
                     .Where(transformedPos => transformedPos.Z < 1))
        {
            minScreenPos.X = Math.Min(minScreenPos.X, transformedPos.X);
            minScreenPos.Y = Math.Min(minScreenPos.Y, transformedPos.Y);
            maxScreenPos.X = Math.Max(maxScreenPos.X, transformedPos.X);
            maxScreenPos.Y = Math.Max(maxScreenPos.Y, transformedPos.Y);
        }

        var healthPercentage = (float)entity.Health / 100;
        var sizeMultiplier = 1.0f + (1.0f - healthPercentage);
        minScreenPos -= new Vector2(padding * sizeMultiplier, padding * sizeMultiplier);
        maxScreenPos += new Vector2(padding * sizeMultiplier, padding * sizeMultiplier);

        return (minScreenPos, maxScreenPos);
    }
}