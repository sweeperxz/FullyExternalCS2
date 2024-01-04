using CS2Cheat.Gfx;
using CS2Cheat.Utils;
using SharpDX;
using Yato.DirectXOverlay;
using Color = SharpDX.Color;
using Graphics = CS2Cheat.Graphics.Graphics;


namespace CS2Cheat.Features;

public static class EspAimCrosshair
{
    public static Vector3 GetPositionScreen(Graphics.Graphics graphics)
    {
        var screenSize = graphics.WindowOverlay.Window.Size;
        var aspectRatio = (double)screenSize.Width / screenSize.Height;
        var player = graphics.GameData.Player;
        var fovY = ((double)player.Fov).DegreeToRadian();
        var fovX = fovY * aspectRatio;
        var punchX = ((double)player.AimPunchAngle.X * Offsets.weapon_recoil_scale).DegreeToRadian();
        var punchY = ((double)player.AimPunchAngle.Y * Offsets.weapon_recoil_scale).DegreeToRadian();

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
        Draw(graphics, GetPositionScreen(graphics));
    }


    private static void Draw(Graphics.Graphics graphics, Vector3 pointScreen)
    {
        const int radius = 3;
        var color = graphics.RedBrush.Color; // Replace this with your actual brush instance

        // Assuming there is a method DrawLine in Yato.DirectXOverlay.Direct2DRenderer
        graphics.D2d.DrawLine(
            pointScreen.X - radius,
            pointScreen.Y,
            pointScreen.X + radius + 1,
            pointScreen.Y,
            1.0f, // Replace this with your desired stroke width
            color
        );

        graphics.D2d.DrawLine(
            pointScreen.X,
            pointScreen.Y - radius,
            pointScreen.X,
            pointScreen.Y + radius + 1,
            1.0f, // Replace this with your desired stroke width
            color
        );
    }
}