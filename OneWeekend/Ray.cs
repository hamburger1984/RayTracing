namespace OneWeekend;

public class Ray
{
    public Point3 Origin { get; }
    public Point3 Direction { get; }

    public Ray(Point3 origin, Point3 direction)
    {
        Origin = origin;
        Direction = direction;
    }

    public Point3 At(float t)
    {
        return Origin + t*Direction;
    }

}