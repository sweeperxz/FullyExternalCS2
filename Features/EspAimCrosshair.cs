using System.Numerics;
using CS2Cheat.Data.Entity;
using CS2Cheat.Data.Game;
using CS2Cheat.Graphics;
using CS2Cheat.Utils;
using ImGuiNET;

namespace CS2Cheat.Features;

public static class EspAimCrosshair
{
    private static Vector3 _pointClip = Vector3.Zero;

    private static Vector2 GetPositionScreen(GameProcess gameProcess, GameData gameData)
    {
        var screenSize = gameProcess.WindowRectangleClient.Size;
        var aspectRatio = (double)screenSize.Width / screenSize.Height;
        var player = gameData.Player;
        if (player == null) return Vector2.Zero;

        var fovY = ((double)Player.Fov).DegreeToRadian();
        var fovX = fovY * aspectRatio;
        var doPunch = player.ShotsFired > 0;
        var punchX = doPunch ? ((double)player.AimPunchAngle.X * Offsets.WeaponRecoilScale).DegreeToRadian() : 0;
        var punchY = doPunch ? ((double)player.AimPunchAngle.Y * Offsets.WeaponRecoilScale).DegreeToRadian() : 0;
        _pointClip = new Vector3
        (
            (float)(-punchY / fovX),
            (float)(-punchX / fovY),
            0
        );
        var pointScreen = player.MatrixViewport.Transform(_pointClip);
        return new Vector2(pointScreen.X, pointScreen.Y);
    }

    public static void Draw(ImDrawListPtr drawList, GameData gameData, GameProcess gameProcess)
    {
        if (gameData.Player == null) return;
        var pointScreen = GetPositionScreen(gameProcess, gameData);
        DrawCrosshair(drawList, pointScreen, 6);
    }

    private static void DrawCrosshair(ImDrawListPtr drawList, Vector2 center, int radius)
    {
        var color = OverlayRenderer.Colors.White;

        drawList.AddLine(center - new Vector2(radius, 0), center + new Vector2(radius, 0), color, 1.5f);
        drawList.AddLine(center - new Vector2(0, radius), center + new Vector2(0, radius), color, 1.5f);
    }
}