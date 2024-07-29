using Lessons.Domain.Aggregates.Lessons;
using Lessons.Domain.Aggregates.Students;
using Lessons.Domain.Aggregates.Teachers;
using Lessons.Domain.Teachers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lessons.Infrastructure.Entities.Configurations;

public class LessonEntityTypeConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.Property(s => s.Id).HasConversion(id => id.Value, value => new LessonId(value));
        builder.Property(s => s.StudentId).HasConversion(id => id.Value, value => new StudentId(value));
        builder.Property(s => s.TeacherId).HasConversion(id => id.Value, value => new TeacherId(value));
        builder.Property(s => s.Duration).HasConversion(d => d.Minutes, value => Duration.Create(value));

        builder
            .Property(l => l.Status)
            .HasConversion<string>();

        builder
            .HasOne<Student>()
            .WithMany()
            .HasForeignKey(l => l.StudentId);

        builder
            .HasOne<Teacher>()
            .WithMany()
            .HasForeignKey(l => l.TeacherId);
    }
}
