using OpenTK.Mathematics;
using System;

public class Transform
{
    public Vector3 Position { get; set; }
    public Quaternion Rotation { get; set; }
    public Vector3 Scale { get; set; } = new Vector3(1.0f, 1.0f, 1.0f);

    public Vector3 Forward()
    {
        Vector3 angles = new Vector3(Rotation.X, Rotation.Y, Rotation.Z) * MathHelper.DegToRad;
        float x = MathF.Sin(angles.Y) * MathF.Cos(angles.X);
        float y = -MathF.Sin(angles.X);
        float z = MathF.Cos(angles.Y) * MathF.Cos(angles.X);
        Vector3 forward = new Vector3(x, y, z);
        return forward;
    }

    public Vector3 Right()
    {
        Vector3 angles = new Vector3(Rotation.X, Rotation.Y, Rotation.Z) * MathHelper.DegToRad;
        Vector3 right = new Vector3(MathF.Sin(angles.Y + MathF.PI / 2), 0f, MathF.Cos(angles.Y + MathF.PI / 2));
        return right;
    }

}