using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trainova.Domain.Courses;

namespace Trainova.Infrastructure.Configurations
{
    public class CourseConfiguration : BaseEntityConfiguration<Course>
    {
        public override void Configure(EntityTypeBuilder<Course> builder)
        {
            // Table
            builder.ToTable("Courses");

            // Properties
            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(2000);

            builder.Property(c => c.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(c => c.CreatedAt)
                .HasDefaultValueSql("NOW()");

            // Index
            builder.HasIndex(c => c.Title);

            // Relationships (optional if navigation exists)
            builder.HasMany(c => c.Enrollments)
                .WithOne(e => e.Course)
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}