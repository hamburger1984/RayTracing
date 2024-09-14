namespace OneWeekend;

public static class Chapter3
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
                var color = new Color((float)x / (width - 1), (float)y / (height - 1), 0.0f);

                await color.WriteAsync(writer);
            }
        }

        Console.WriteLine("\nDone");
    }
}