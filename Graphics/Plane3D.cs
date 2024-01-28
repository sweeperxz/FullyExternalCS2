using SharpDX;

namespace CS2Cheat.Graphics;

public readonly struct Plane3D
{
    public readonly Vector3 Normal;


    private readonly float _distance;


    private Plane3D(Vector3 normal, float distance)
    {
        Normal = normal.GetNormalized();
        _distance = distance;
    }

    public Plane3D(Vector3 normal, Vector3 point) :
        this(normal, -Vector3.Dot(normal, point))
    {
    }


    public (Vector3 planeOrigin, Vector3 vector) ProjectVector(Vector3 vector)
    {
        var planeOrigin = ProjectPoint(new Vector3());
        return (planeOrigin, ProjectPoint(vector) - planeOrigin);
    }

    /// <summary>
    ///     Project point on a plane.
    /// </summary>
    /// <remarks>
    ///     "https://en.wikipedia.org/wiki/3D_projection"
    ///     "https://en.wikipedia.org/wiki/Projection_(linear_algebra)"
    /// </remarks>
    private Vector3 ProjectPoint(Vector3 point)
    {
        return point - (Vector3.Dot(Normal, point) + _distance) * Normal;
    }
}