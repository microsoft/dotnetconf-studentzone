using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("WaterConsumption") ?? "Data Source=WaterConsumption.db";

builder.Services.AddSqlite<WaterConsumptionDb>(connectionString);

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
  string secret = Environment.GetEnvironmentVariable("secret");
  if (key == secret) {
    return Results.Ok(db.Entries.ToList());
  } else {
   
    return Results.StatusCode(401);
  }
});

app.MapGet("/", () => "Hello World!");
// app.MapGet("/resume", (ResumeDb db) => {
//   return db.Resumes
//   .Include(r => r.Skills)
//   .Include(r => r.Educations)
//   .Include(r => r.Experiences)
//   .ToList();
// });

app.Run();


