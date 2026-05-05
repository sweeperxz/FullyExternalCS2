using System.Numerics;
using CS2Cheat.Core.Data;
using CS2Cheat.Data.Entity;
using CS2Cheat.Data.Game;
using CS2Cheat.Graphics;
using ImGuiNET;

namespace CS2Cheat.Features;

public static class SkeletonEsp
{
    private static readonly (string Start, string End)[] BoneConnections =
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

    public static void Draw(ImDrawListPtr drawList, GameData gameData)
    {
        var player = gameData.Player;
        if (player == null || gameData.Entities == null) return;

        foreach (var entity in gameData.Entities)
        {
            if (!IsValidEntity(entity, player)) continue;

            var color = GetTeamColor(entity.Team);
            DrawSkeleton(drawList, player, entity, color);
        }
    }

    private static bool IsValidEntity(Entity entity, Player player)
    {
        return entity.IsAlive() &&
               entity.AddressBase != player.AddressBase;
    }

    private static uint GetTeamColor(Team team)
    {
        return team == Team.Terrorists
            ? OverlayRenderer.Colors.Yellow
            : OverlayRenderer.Colors.Blue;
    }

    private static void DrawSkeleton(ImDrawListPtr drawList, Player player, Entity entity, uint color)
    {
        var bonePositions = entity.BonePos;
        if (bonePositions == null) return;

        var matrix = player.MatrixViewProjectionViewport;

        foreach (var (startBone, endBone) in BoneConnections)
        {
            if (!bonePositions.TryGetValue(startBone, out var startWorld) ||
                !bonePositions.TryGetValue(endBone, out var endWorld))
                continue;

            var startScreen = matrix.Transform(startWorld);
            var endScreen = matrix.Transform(endWorld);

            if (startScreen.Z >= 1 || endScreen.Z >= 1) continue;

            drawList.AddLine(
                new Vector2(startScreen.X, startScreen.Y),
                new Vector2(endScreen.X, endScreen.Y),
                color, 1.5f);
        }
    }
}