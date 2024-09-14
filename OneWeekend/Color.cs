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
    
}