using System.Numerics;

namespace CS2Cheat.Graphics;

public readonly struct Plane3D
{
    public readonly Vector3 Normal;

    private readonly float _distance;

    private Plane3D(Vector3 normal, float distance)
    {
        Normal = Vector3.Normalize(normal);
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

    private Vector3 ProjectPoint(Vector3 point)
    {
        return point - (Vector3.Dot(Normal, point) + _distance) * Normal;
    }
}