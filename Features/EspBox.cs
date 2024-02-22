using CS2Cheat.Core.Data;
using CS2Cheat.Data.Entity;
using CS2Cheat.Graphics;
using SharpDX;
using SharpDX.Direct3D9;
using Color = SharpDX.Color;

namespace CS2Cheat.Features;

public static class EspBox
{
    public static void Draw(Graphics.Graphics graphics)
    {
        foreach (var entity in graphics.GameData.Entities)
        {
            if (!entity.IsAlive() || entity.AddressBase == graphics.GameData.Player.AddressBase) continue;

            var colorBox = entity.Team == Team.Terrorists ? Color.DarkRed : Color.DarkBlue;

            DrawEntityRectangle(graphics, entity, colorBox, 3f);
        }
    }

    private static void DrawEntityRectangle(Graphics.Graphics graphics, Entity entity, Color color, float thickness)
    {
        const float healthBarWidth = 10.0f;
        const float healthBarPadding = 2.0f;

        var boundingBox = GetEntityBoundingBox(graphics, entity);
        var healthPercentage = (float)entity.Health / 100;

        //thickness
        for (float i = 0; i < thickness; i++)
        {
            var thickTopLeft = new Vector2(boundingBox.Item1.X - i, boundingBox.Item1.Y - i);
            var thickBottomRight = new Vector2(boundingBox.Item2.X + i, boundingBox.Item2.Y + i);
            graphics.DrawRectangle(color, thickTopLeft, thickBottomRight);
        }

        //health bar
        var healthBarTopLeft =
            new Vector2(boundingBox.Item1.X - healthBarWidth - healthBarPadding, boundingBox.Item1.Y);
        var healthBarBottomRight = new Vector2(healthBarTopLeft.X + healthBarWidth, boundingBox.Item2.Y);

        // heath bar num
        graphics.FontConsolas32.DrawText(default, $"{entity.Health}", (int)healthBarTopLeft.X - 20,
            (int)healthBarBottomRight.Y,
            Color.LightGreen);

        DrawHealthBar(graphics, healthBarTopLeft, healthBarBottomRight, healthPercentage);

        //weapon name
        var currentWeaponName = entity.CurrentWeaponName ?? "NONE";
        var textWidth = graphics.FontConsolas32.MeasureText(null, currentWeaponName, FontDrawFlags.Center).Right + 30;

        var weaponNamePosition = new Vector2(
            (boundingBox.Item1.X + boundingBox.Item2.X - textWidth) / 2,
            boundingBox.Item2.Y + 5f
        );
        graphics.FontConsolas32.DrawText(default, $"{currentWeaponName}", (int)weaponNamePosition.X,
            (int)weaponNamePosition.Y,
            Color.White);


        // enemy name
        var enemyNamePosition = new Vector2(
            (boundingBox.Item1.X + boundingBox.Item2.X) / 2,
            boundingBox.Item1.Y - 15f
        );

        if (graphics.GameData.Player.Team != entity.Team)
        {
            var entityName = entity.Name ?? "UNKNOWN";
            var textWidth2 = graphics.FontConsolas32.MeasureText(null, entityName, FontDrawFlags.Center).Right + 10f;
            enemyNamePosition.X -= textWidth2 / 2;
            graphics.FontConsolas32.DrawText(default, entityName, (int)enemyNamePosition.X,
                (int)enemyNamePosition.Y,
                Color.White);
        }


        //flags 
        var flagsPosition = new Vector2(boundingBox.Item2.X + 5f, boundingBox.Item1.Y);

        var scoped = entity.IsinScope == 0
            ? graphics.FontConsolas32.DrawText(default, "Scoped", (int)flagsPosition.X, (int)flagsPosition.Y,
                Color.White)
            : default;

        var flashed = entity.FlashAlpha == 0
            ? graphics.FontConsolas32.DrawText(default, "Flashed", (int)flagsPosition.X, (int)flagsPosition.Y + 15,
                Color.White)
            : default;

        var shifting = entity.IsinScope == 0
            ? graphics.FontConsolas32.DrawText(default, "Shifting", (int)flagsPosition.X, (int)flagsPosition.Y + 30,
                Color.White)
            : default;

        var shiftingInScope = entity.IsinScope == 0
            ? graphics.FontConsolas32.DrawText(default, "Shifting in scope", (int)flagsPosition.X,
                (int)flagsPosition.Y + 45,
                Color.White)
            : default;
    }


    private static void DrawHealthBar(Graphics.Graphics graphics, Vector2 topLeft, Vector2 bottomRight,
        float healthPercentage)
    {
        var filledHeight = (bottomRight.Y - topLeft.Y) * healthPercentage;

        graphics.DrawRectangle(Color.Gray, topLeft, bottomRight);
        graphics.DrawRectangle(Color.Green, new Vector2(topLeft.X, bottomRight.Y - filledHeight), bottomRight);
    }

    private static (Vector2, Vector2) GetEntityBoundingBox(Graphics.Graphics graphics, Entity entity)
    {
        const float padding = 5.0f;
        var minScreenPos = new Vector2(float.MaxValue, float.MaxValue);
        var maxScreenPos = new Vector2(float.MinValue, float.MinValue);

        foreach (var bonePos in entity.BonePos
                     .Select(bone => graphics.GameData.Player.MatrixViewProjectionViewport.Transform(bone.Value))
                     .Where(bonePos => bonePos.Z < 1))
        {
            minScreenPos.X = Math.Min(minScreenPos.X, bonePos.X);
            minScreenPos.Y = Math.Min(minScreenPos.Y, bonePos.Y);
            maxScreenPos.X = Math.Max(maxScreenPos.X, bonePos.X);
            maxScreenPos.Y = Math.Max(maxScreenPos.Y, bonePos.Y);
        }

        var healthPercentage = (float)entity.Health / 100;
        var sizeMultiplier = 1.0f + (1.0f - healthPercentage);
        minScreenPos -= new Vector2(padding * sizeMultiplier, padding * sizeMultiplier);
        maxScreenPos += new Vector2(padding * sizeMultiplier, padding * sizeMultiplier);

        return (minScreenPos, maxScreenPos);
    }
}