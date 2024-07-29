using Lessons.Domain.Aggregates.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lessons.Infrastructure.Entities.Configurations;

public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.Property(s => s.Id).HasConversion(id => id.Value, value => new StudentId(value));

        // builder
        //     .OwnsMany(s => s.Subscriptions, sub =>
        //     {
        //         sub.WithOwner().HasForeignKey(sub => sub.StudentId);
        //         sub.Property(sub => sub.Id).HasConversion(id => id.Value, value => new SubscriptionId(value));
        //         sub.HasKey(sub => sub.Id);
        //     });
    }
}
