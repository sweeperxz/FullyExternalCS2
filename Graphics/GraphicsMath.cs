using SharpDX;

namespace CS2Cheat.Gfx;

public static class GraphicsMath
{
    public static Matrix GetMatrixViewport(Size screenSize)
    {
        return GetMatrixViewport(new Viewport
        {
            X = 0,
            Y = 0,
            Width = screenSize.Width,
            Height = screenSize.Height,
            MinDepth = 0,
            MaxDepth = 1
        });
    }

    /// <summary>
    ///     Get viewport matrix.
    /// </summary>
    public static Matrix GetMatrixViewport(in Viewport viewport)
    {
        return new Matrix
        {
            M11 = viewport.Width * 0.5f,
            M12 = 0,
            M13 = 0,
            M14 = 0,

            M21 = 0,
            M22 = -viewport.Height * 0.5f,
            M23 = 0,
            M24 = 0,

            M31 = 0,
            M32 = 0,
            M33 = viewport.MaxDepth - viewport.MinDepth,
            M34 = 0,

            M41 = viewport.X + viewport.Width * 0.5f,
            M42 = viewport.Y + viewport.Height * 0.5f,
            M43 = viewport.MinDepth,
            M44 = 1
        };
    }

    /// <summary>
    ///     Transform value.
    /// </summary>
    public static Vector3 Transform(this in Matrix matrix, Vector3 value)
    {
        var wInv = 1.0 / (matrix.M14 * (double)value.X + matrix.M24 * (double)value.Y +
                          matrix.M34 * (double)value.Z + matrix.M44);
        return new Vector3
        (
            (float)((matrix.M11 * (double)value.X + matrix.M21 * (double)value.Y +
                     matrix.M31 * (double)value.Z + matrix.M41) * wInv),
            (float)((matrix.M12 * (double)value.X + matrix.M22 * (double)value.Y +
                     matrix.M32 * (double)value.Z + matrix.M42) * wInv),
            (float)((matrix.M13 * (double)value.X + matrix.M23 * (double)value.Y +
                     matrix.M33 * (double)value.Z + matrix.M43) * wInv)
        );
    }
}