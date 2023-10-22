var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/api", () => "Hello World!");

app.Run();
