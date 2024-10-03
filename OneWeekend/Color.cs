namespace OneWeekend;

public class Color:Vec3
{
    public Color(float r, float g, float b):base(r,g,b)
    {
    }

    public void Write(StreamWriter writer)
    {
        var r = (byte)(255.999f * X);
        var g = (byte)(255.999f * Y);
        var b = (byte)(255.999f * Z);

        writer.WriteLine($"{r} {g} {b}");
    }
    
    public async Task WriteAsync(StreamWriter writer)
    {
        var r = (byte)(255.999f * X);
        var g = (byte)(255.999f * Y);
        var b = (byte)(255.999f * Z);

        await writer.WriteLineAsync($"{r} {g} {b}");
    }
    
    public static Color operator +(Color a, Color b)
    {
        return new Color(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    public static Color operator *(Color a, float b)
    {
        return new Color(a.X * b, a.Y * b, a.Z * b);
    }
    
    public static Color operator *(float a, Color b)
    {
        return new Color(a * b.X, a * b.Y, a * b.Z);
    }
    
}