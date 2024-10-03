using System.Drawing;

namespace OneWeekend;

public static class Chapter6
{
    private static readonly Color White = new Color(1, 1, 1);
    private static readonly Color Blueish = new Color(0.5f, 0.7f, 1);
    private static readonly Color Red = new Color(1, 0, 0);

    private static float HitSphere(Point3 center, float radius, Ray ray)
    {
        var oc = center - ray.Origin;
        var rayDir = ray.Direction;
        var a = rayDir.Dot(rayDir);
        var b = -2f * rayDir.Dot(oc);
        var c = oc.Dot(oc) - radius * radius;
        var discriminant = b * b - 4f * a * c;

        if (discriminant < 0)
            return -1f;
        return (-b - MathF.Sqrt(discriminant)) / (2f * a);
    }

    private static readonly Point3 SphereCenter = new Point3(0, 0, -1f);
    private const float SphereRadius = 0.5f;

    private static Color RayColor(Ray ray)
    {
        var t = HitSphere(SphereCenter, SphereRadius, ray);

        if (t > 0)
        {
            var n = ray.At(t) - SphereCenter;
            return 0.5f * new Color(n.X + 1f, n.Y + 1f, n.Z + 1f);
        }

        var unitDirection = ray.Direction.Normalize();
        var a = 0.5f * (unitDirection.Y + 1f);
        return (1f - a) * White + a * Blueish;
    }

    public static async Task RenderImage(Stream stream, int imageWidth)
    {
        await using var writer = new StreamWriter(stream);

        // Image
        const float aspectRatio = 16f / 9f;
        var imageHeight = Math.Max(1, (int)(imageWidth / aspectRatio));

        // Camera
        const float focalLength = 1f;
        const float viewportHeight = 2f;
        var viewportWidth = viewportHeight * (imageWidth / (float)imageHeight);

        var cameraCenter = new Point3(0, 0, 0);

        // Calculate the vectors across the horizontal and down the vertical viewport edges.
        var viewportEdges = (U: new Vec3(viewportWidth, 0, 0), V: new Vec3(0, -viewportHeight, 0));

        // Calculate the horizontal and vertical delta vectors from pixel to pixel
        var pixelDelta = (U: viewportEdges.U / imageWidth, V: viewportEdges.V / imageHeight);

        // Calculate the location of the upper left pixel
        var viewportUpperLeft = cameraCenter - new Vec3(0, 0, focalLength) - viewportEdges.U / 2 - viewportEdges.V / 2;
        var pixel00Loc = viewportUpperLeft + 0.5f * (pixelDelta.U + pixelDelta.V);

        // Render
        await writer.WriteAsync($"P3\n{imageWidth} {imageHeight}\n255\n");

        for (var y = 0; y < imageHeight; y++)
        {
            var (left, _) = Console.GetCursorPosition();
            Console.Write(new string('\b', left) + $"Remaining {(imageHeight - y),5}");
            for (var x = 0; x < imageWidth; x++)
            {
                var pixelCenter = pixel00Loc + (x * pixelDelta.U) + (y * pixelDelta.V);
                var rayDirection = pixelCenter + cameraCenter;
                var ray = new Ray(cameraCenter, rayDirection);

                var color = RayColor(ray);
                await color.WriteAsync(writer);
            }
        }

        Console.WriteLine("\nDone");
    }
}