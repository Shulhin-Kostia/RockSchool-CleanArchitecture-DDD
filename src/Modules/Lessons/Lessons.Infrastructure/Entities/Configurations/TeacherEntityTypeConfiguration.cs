using Lessons.Domain.Aggregates.Teachers;
using Lessons.Domain.Teachers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lessons.Infrastructure.Entities.Configurations;

public class TeacherEntityTypeConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder.Property(s => s.Id).HasConversion(id => id.Value, value => new TeacherId(value));
        // builder.HasMany<SubscriptionType>().WithMany();

        // builder.Ignore(st => st.SubscriptionTypes);
    }
}
