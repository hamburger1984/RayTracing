namespace OneWeekend;

public class Vec3
{
    private readonly float[] e;

    public Vec3() : this(0, 0, 0)
    {
    }

    public Vec3(float x, float y, float z)
    {
        e = [x, y, z];
    }


    public float X => e[0];
    public float Y => e[1];
    public float Z => e[2];

    public float this[int i] => e[i];

    public float LengthSquared => X * X + Y * Y + Z * Z;

    public float Length => MathF.Sqrt(LengthSquared);

    public void Write(StreamWriter writer)
    {
        writer.Write($"{e[0]} {e[1]} {e[2]}");
    }

    public static Vec3 operator -(Vec3 v)
    {
        return new Vec3(-v.X, -v.Y, -v.Z);
    }

    public static Vec3 operator *(Vec3 a, Vec3 b)
    {
        return new Vec3(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
    }

    public static Vec3 operator -(Vec3 a, Vec3 b)
    {
        return new Vec3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static Vec3 operator +(Vec3 a, Vec3 b)
    {
        return new Vec3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    public static Vec3 operator *(Vec3 a, float b)
    {
        return new Vec3(a.X * b, a.Y * b, a.Z * b);
    }

    public static Vec3 operator /(Vec3 a, float b)
    {
        return a * (1.0f / b);
    }

    public float Dot(Vec3 other)
    {
        return X * other.X + Y * other.Y + Z * other.Z;
    }

    public Vec3 Cross(Vec3 other)
    {
        return new Vec3(
            Y * other.Z - Z * other.Y,
            Z * other.X - X * other.Z,
            X * other.Y - Y * other.X
        );
    }

    public Vec3 Normalize()
    {
        return this / Length;
    }
}