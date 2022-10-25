using Microsoft.EntityFrameworkCore;

namespace API.Models;

public class ResumeDb : DbContext
{
    public ResumeDb(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        new DbInitializer().Seed(modelBuilder);
    }

    public DbSet<Education> Educations { get; set; } = null!;
    public DbSet<Skill> Skills { get; set; } = null!;
    public DbSet<Experience> Experiences { get; set; } = null!;
    public DbSet<Resume> Resumes { get; set; } = null!;
}

public class Education
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string DegreeYear { get; set; }
    public string Description { get; set; }
    public int ResumeId { get; set; }
};

public class Experience
{
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public string Title { get; set; }
    public string Tenure { get; set; }
    public string Description { get; set; }
    public int ResumeId { get; set; }
};

public class Skill
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int EstimatedLevel { get; set; }
    public string EstimatedDescription { get; set; }
    public int ResumeId { get; set; }
}
public class Resume
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Education> Educations { get; set; }
    public ICollection<Experience> Experiences { get; set; }
    public ICollection<Skill> Skills { get; set; }
};