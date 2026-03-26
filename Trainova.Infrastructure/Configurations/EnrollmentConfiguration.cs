using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trainova.Domain.Enrollments;

namespace Trainova.Infrastructure.Configurations
{
    public class EnrollmentConfiguration : BaseEntityConfiguration<Enrollment>
    {
        public override void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            // Table
            builder.ToTable("Enrollments");

            // Properties
            builder.Property(e => e.UserProfileId)
                .IsRequired();

            builder.Property(e => e.CourseId)
                .IsRequired();
           
            builder.Property(e => e.CreatedAt)
                .HasDefaultValueSql("NOW()");

            // Index (Prevent duplicate enrollments)
            builder.HasIndex(e => new { e.UserProfileId, e.CourseId })
                .IsUnique();

            // Relationships
            builder.HasOne(e => e.UserProfile)
                .WithMany(p => p.Enrollments)
                .HasForeignKey(e => e.UserProfileId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}