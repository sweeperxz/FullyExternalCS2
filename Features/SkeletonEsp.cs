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
        (string, string)[] bones =
        [
            ("head", "neck_0"),
            ("neck_0", "spine_1"),
            ("spine_1", "spine_2"),
            ("spine_2", "pelvis"),
            ("spine_1", "arm_upper_L"),
            ("arm_upper_L", "arm_lower_L"),
            ("arm_lower_L", "hand_L"),
            ("spine_1", "arm_upper_R"),
            ("arm_upper_R", "arm_lower_R"),
            ("arm_lower_R", "hand_R"),
            ("pelvis", "leg_upper_L"),
            ("leg_upper_L", "leg_lower_L"),
            ("leg_lower_L", "ankle_L"),
            ("pelvis", "leg_upper_R"),
            ("leg_upper_R", "leg_lower_R"),
            ("leg_lower_R", "ankle_R")
        ];

        foreach (var (startBone, endBone) in bones)
            graphics.DrawLineWorld(color, entity.BonePos[startBone], entity.BonePos[endBone]);
    }
}