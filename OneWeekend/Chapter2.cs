namespace OneWeekend;

public static class Chapter2
{
    public static async Task SimpleGradient(Stream stream, int width, int height)
    {
        await using var writer = new StreamWriter(stream);

        await writer.WriteAsync($"P3\n{width} {height}\n255\n");

        for (var y = 0; y < height; y++)
        {
            var (left, _) = Console.GetCursorPosition();
            Console.Write(new string('\b', left) + $"Line {y + 1} of {height}");
            for (var x = 0; x < width; x++)
            {
                var r = (double)x / (width - 1);
                var g = (double)y / (height - 1);
                var b = 0.0;

                await writer.WriteAsync($"{(int)(r * 255.999)} {(int)(g * 255.999)} {(int)(b * 255.999)}\n");
            }
        }

        Console.WriteLine("\nDone");
    }
}