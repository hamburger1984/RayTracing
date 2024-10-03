namespace OneWeekend;

public class Point3 : Vec3
{
    public Point3(float x, float y, float z) : base(x, y, z)
    {
    }

    public static Point3 operator *(Point3 a, float b)
    {
        return new Point3(a.X * b, a.Y * b, a.Z * b);
    }

    public static Point3 operator *(float a, Point3 b)
    {
        return new Point3(a * b.X, a * b.Y, a * b.Z);
    }

    public static Point3 operator +(Point3 a, Vec3 b)
    {
        return new Point3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }
    
    public static Point3 operator -(Point3 a, Vec3 b)
    {
        return new Point3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }
}