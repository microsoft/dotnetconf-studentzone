using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
// var connectionString = builder.Configuration.GetConnectionString("WaterConsumption") ?? "Data Source=WaterConsumption.db";
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                          policy =>
                          {
                              policy.WithOrigins("*")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});


var connectionString = builder.Configuration.GetConnectionString("DB");
builder.Services.AddSqlServer<WaterConsumptionDb>(connectionString);
// builder.Services.AddSqlite<WaterConsumptionDb>(connectionString);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
  c.SwaggerDoc("v1", new OpenApiInfo { Title = "Water Consumption API", Description = "an API for Water Consumption", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
  c.SwaggerEndpoint("/swagger/v1/swagger.json", "Water Consumption API V1");
});

app.MapGet("/Consumption", ([FromHeader(Name = "dotnetconfstudentzone")] string ? key, WaterConsumptionDb db) => {
  string ? secret = Environment.GetEnvironmentVariable("secret");
  if (key == secret) {
    return Results.Ok(db.WaterEntry.ToList());
  } else {
   
    return Results.StatusCode(401);
  }
});

app.MapGet("/", () => "Hello World!");
app.MapGet("/hello", () => "hello");
app.MapPost("/Consumption", (
  [FromHeader(Name = "dotnetconfstudentzone")] string ? key, 
  WaterEntry entry,
  WaterConsumptionDb db ) => {
  
  string ? secret = Environment.GetEnvironmentVariable("secret");
  if (key == secret) {
    int items = db.WaterEntry.Count();
    entry.Id = items + 1;
    // entry.DateTime = DateTime.Now;
    db.WaterEntry.Add(entry);
    db.SaveChanges();
    return Results.Ok(entry);
  } else {
    return Results.StatusCode(401);
  }
});

app.UseCors(MyAllowSpecificOrigins);

app.Run();


