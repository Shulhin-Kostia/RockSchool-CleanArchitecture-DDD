using BuildingBlocks.Infrastructure;
using Lessons.Domain.Aggregates.Lessons;
using Lessons.Domain.Aggregates.Students;
using Lessons.Domain.Aggregates.SubscriptionTypes;
using Lessons.Domain.Aggregates.Teachers;
using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Logging;

namespace Lessons.Infrastructure;

public class LessonsContext : AppDbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<SubscriptionType> SubscriptionTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseLoggerFactory(loggerFactory).EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("lessons");

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
