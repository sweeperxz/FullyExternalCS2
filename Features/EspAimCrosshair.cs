using CS2Cheat.Data;
using CS2Cheat.Gfx;
using CS2Cheat.Utils;
using SharpDX;
using Color = System.Drawing.Color;


namespace CS2Cheat.Features;

public static class EspAimCrosshair
{
    public static Vector3 GetPositionScreen(GameProcess gameProcess, GameData gameData)
    {
        var screenSize = gameProcess.WindowRectangleClient.Size;
        var aspectRatio = (double)screenSize.Width / screenSize.Height;
        var player = gameData.Player;
        var fovY = ((double)90).DegreeToRadian();
        var fovX = fovY * aspectRatio;

        var doPunch = player.ShotsFired > 0;

        var punchX = doPunch ? ((double)player.AimPunchAngle.X * Offsets.weapon_recoil_scale).DegreeToRadian() : 0;
        var punchY = doPunch ? ((double)player.AimPunchAngle.Y * Offsets.weapon_recoil_scale).DegreeToRadian() : 0;

        var pointClip = new Vector3
        (
            (float)(-punchY / fovX),
            (float)(-punchX / fovY),
            0
        );
        return player.MatrixViewport.Transform(pointClip);
    }


    public static void Draw(Graphics.Graphics graphics)
    {
        var pointScreen = GetPositionScreen(graphics.GameProcess, graphics.GameData);
        Draw(graphics, new Vector2(pointScreen.X, pointScreen.Y));
    }

    private static void Draw(Graphics.Graphics graphics, Vector2 pointScreen)
    {
        const int radius = 12;
        graphics.DrawLine(SharpDX.Color.Red, pointScreen - new Vector2(radius, 0),
            pointScreen + new Vector2(radius, 0));
        graphics.DrawLine(SharpDX.Color.Red, pointScreen - new Vector2(0, radius),
            pointScreen + new Vector2(0, radius));
    }
}