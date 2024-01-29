using CS2Cheat.Core.Data;
using CS2Cheat.Data.Entity;
using CS2Cheat.Graphics;
using SharpDX;
using Color = SharpDX.Color;

namespace CS2Cheat.Features;

public static class EspVisuals
{
    public static void Draw(Graphics.Graphics graphics)
    {
        foreach (var entity in graphics.GameData.Entities)
        {
            if (!entity.IsAlive() || entity.AddressBase == graphics.GameData.Player.AddressBase) continue;

            var colorBones = entity.Team == Team.Terrorists ? Color.Yellow : Color.Blue;
            var colorBox = entity.Team == Team.Terrorists ? Color.DarkRed : Color.DarkBlue;

            DrawBones(graphics, entity, colorBones);
            DrawEntityRectangle(graphics, entity, colorBox, 2f);
        }
    }

    private static void DrawBones(Graphics.Graphics graphics, Entity entity, Color color)
    {
        graphics.DrawLineWorld(color, entity.BonePos["head"], entity.BonePos["neck_0"]);
        graphics.DrawLineWorld(color, entity.BonePos["neck_0"], entity.BonePos["spine_1"]);
        graphics.DrawLineWorld(color, entity.BonePos["spine_1"], entity.BonePos["spine_2"]);
        graphics.DrawLineWorld(color, entity.BonePos["spine_2"], entity.BonePos["pelvis"]);
        graphics.DrawLineWorld(color, entity.BonePos["spine_1"], entity.BonePos["arm_upper_L"]);
        graphics.DrawLineWorld(color, entity.BonePos["arm_upper_L"], entity.BonePos["arm_lower_L"]);
        graphics.DrawLineWorld(color, entity.BonePos["arm_lower_L"], entity.BonePos["hand_L"]);
        graphics.DrawLineWorld(color, entity.BonePos["spine_1"], entity.BonePos["arm_upper_R"]);
        graphics.DrawLineWorld(color, entity.BonePos["arm_upper_R"], entity.BonePos["arm_lower_R"]);
        graphics.DrawLineWorld(color, entity.BonePos["arm_lower_R"], entity.BonePos["hand_R"]);
        graphics.DrawLineWorld(color, entity.BonePos["pelvis"], entity.BonePos["leg_upper_L"]);
        graphics.DrawLineWorld(color, entity.BonePos["leg_upper_L"], entity.BonePos["leg_lower_L"]);
        graphics.DrawLineWorld(color, entity.BonePos["leg_lower_L"], entity.BonePos["ankle_L"]);
        graphics.DrawLineWorld(color, entity.BonePos["pelvis"], entity.BonePos["leg_upper_R"]);
        graphics.DrawLineWorld(color, entity.BonePos["leg_upper_R"], entity.BonePos["leg_lower_R"]);
        graphics.DrawLineWorld(color, entity.BonePos["leg_lower_R"], entity.BonePos["ankle_R"]);
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

        DrawHealthBar(graphics, healthBarTopLeft, healthBarBottomRight, healthPercentage);
    }

    private static void DrawHealthBar(Graphics.Graphics graphics, Vector2 topLeft, Vector2 bottomRight,
        float healthPercentage)
    {
        var filledHeight = (bottomRight.Y - topLeft.Y) * healthPercentage;

        graphics.DrawRectangle(Color.Gray, topLeft, bottomRight);
        graphics.DrawRectangle(Color.Green, new Vector2(topLeft.X, bottomRight.Y - filledHeight), bottomRight);
    }

    private static Tuple<Vector2, Vector2> GetEntityBoundingBox(Graphics.Graphics graphics, Entity entity)
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

        return new Tuple<Vector2, Vector2>(minScreenPos, maxScreenPos);
    }
}