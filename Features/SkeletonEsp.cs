using CS2Cheat.Core.Data;
using CS2Cheat.Data.Entity;
using Color = SharpDX.Color;

namespace CS2Cheat.Features;

public static class SkeletonEsp
{
    public static void Draw(Graphics.Graphics graphics)
    {
        foreach (var entity in graphics.GameData.Entities)
        {
            if (!entity.IsAlive() || entity.AddressBase == graphics.GameData.Player.AddressBase) continue;

            var colorBones = entity.Team == Team.Terrorists ? Color.Yellow : Color.Blue;

            DrawBones(graphics, entity, colorBones);
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
}