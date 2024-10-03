using OneWeekend;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("chapter2",
    (int width = 600, int height = 400) =>
    {
        return Results.Stream(
            async s => { await Chapter2.SimpleGradient(s, width, height); },
            "image/x-portable-pixmap",
            $"Chapter2_{width}x{height}.ppm");
    });

app.MapGet("chapter3",
    (int width = 600, int height = 400) =>
    {
        return Results.Stream(
            async s => { await Chapter3.SimpleGradient(s, width, height); },
            "image/x-portable-pixmap",
            $"Chapter3_{width}x{height}.ppm");
    });

app.MapGet("chapter4",
    (int width = 800) =>
    {
        return Results.Stream(
            async s => { await Chapter4.RenderImage(s, width); },
            "image/x-portable-pixmap",
            $"Chapter4_{width}.ppm");
    });

app.MapGet("chapter5",
    (int width = 800) =>
    {
        return Results.Stream(
            async s => { await Chapter5.RenderImage(s, width); },
            "image/x-portable-pixmap",
            $"Chapter5_{width}.ppm");
    });

app.Run();