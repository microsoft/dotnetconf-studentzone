using System.Text.Json;
using MinimalApi.Models;

JsonSerializerOptions jsonSerializerOptions = new()
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    PropertyNameCaseInsensitive = true
};

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
WebApplication app = builder.Build();

app.MapGet("/api/healthcheck", () => "Ok");

app.MapGet("/api/sessions", async () =>
{
    FileStream fileStream = File.OpenRead("data/sessionize.json");
    Sessionize[]? data = await JsonSerializer.DeserializeAsync<Sessionize[]>(fileStream, options: jsonSerializerOptions);

    if (data is null)
    {
        return Results.BadRequest();
    }

    return Results.Json(data);
});

string selectionsPath = "data/selections.json";
app.MapGet("/api/user/selections", async () =>
{
    if (!File.Exists(selectionsPath))
    {
        return Results.Json(Array.Empty<string>());
    }

    FileStream fileStream = File.OpenRead(selectionsPath);

    return Results.Json(await JsonSerializer.DeserializeAsync<string[]>(fileStream, options: jsonSerializerOptions));
});

app.MapPost("/api/user/selections", async (string[] selections) =>
{
    await File.WriteAllTextAsync(selectionsPath, JsonSerializer.Serialize(selections, options: jsonSerializerOptions));

    return Results.Ok();
});

app.Run();
