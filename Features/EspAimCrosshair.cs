using CS2Cheat.Data.Game;
using CS2Cheat.Graphics;
using CS2Cheat.Utils;
using SharpDX;


namespace CS2Cheat.Features;

public static class EspAimCrosshair
{
    private static Vector3 _pointClip = Vector3.Zero;

    public static Vector3 GetPositionScreen(GameProcess gameProcess, GameData gameData)
    {
        var screenSize = gameProcess.WindowRectangleClient.Size;
        var aspectRatio = (double)screenSize.Width / screenSize.Height;
        var player = gameData.Player;
        var fovY = 90.0.DegreeToRadian();
        var fovX = fovY * aspectRatio;

        var doPunch = player.ShotsFired > 0;
        const float recoilScale = Offsets.WeaponRecoilScale;

        var punchX = doPunch ? ((double)player.AimPunchAngle.X * recoilScale).DegreeToRadian() : 0;
        var punchY = doPunch ? ((double)player.AimPunchAngle.Y * recoilScale).DegreeToRadian() : 0;

        _pointClip.X = (float)(-punchY / fovX);
        _pointClip.Y = (float)(-punchX / fovY);
        _pointClip.Z = 0;

        return player.MatrixViewport.Transform(_pointClip);
    }

    public static void Draw(Graphics.Graphics graphics)
    {
        var pointScreen = GetPositionScreen(graphics.GameProcess, graphics.GameData);
        Draw(graphics, new Vector2(pointScreen.X, pointScreen.Y));
    }

    private static void Draw(Graphics.Graphics graphics, Vector2 pointScreen)
    {
        const int crosshairRadius = 12;
        DrawCrosshair(graphics, pointScreen, crosshairRadius);
    }

    private static void DrawCrosshair(Graphics.Graphics graphics, Vector2 pointScreen, int radius)
    {
        graphics.DrawLine(SharpDX.Color.Green, pointScreen - new Vector2(radius, 0),
            pointScreen + new Vector2(radius, 0));
        graphics.DrawLine(SharpDX.Color.Green, pointScreen - new Vector2(0, radius),
            pointScreen + new Vector2(0, radius));
    }
}