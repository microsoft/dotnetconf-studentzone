using Microsoft.OpenApi.Models;
using API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Resumes") ?? "Data Source=Resumes.db";

builder.Services.AddSqlite<ResumeDb>(connectionString);

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapGet("/", (ResumeDb db) =>
{
    db.Database.EnsureCreated();
    return "Hello World!";
});

app.MapGet("/resume", GetResumes);

List<Resume> GetResumes(ResumeDb resumeDb, string? byUser)
{
    IQueryable<Resume> filter = resumeDb.Resumes;
    if (!string.IsNullOrEmpty(byUser))
    {
        filter = resumeDb.Resumes.Where(r => r.Name == byUser);
    }

    var ret = filter
        .Include(r => r.Skills)
        .Include(r => r.Educations)
        .Include(r => r.Experiences)
        .ToList();
    return ret;
}

app.Run();


