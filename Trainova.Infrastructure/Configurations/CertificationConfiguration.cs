using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trainova.Domain.Certificates;

namespace Trainova.Infrastructure.Configurations
{
    public class CertificationConfiguration : BaseEntityConfiguration<Certificate>
    {
        public override void Configure(EntityTypeBuilder<Certificate> builder)
        {
            // Table
            builder.ToTable("Certificates");

            // Properties
            builder.Property(c => c.CertificateCode)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);

            builder.Property(c => c.UserProfileId)
                .IsRequired();

            builder.Property(c => c.CourseId)
                .IsRequired();

            builder.Property(c => c.CreatedAt)
                .HasDefaultValueSql("NOW()");

            // Indexes (IMPORTANT for performance + uniqueness)
            builder.HasIndex(c => c.CertificateCode)
                .IsUnique();

            builder.HasIndex(c => new { c.UserProfileId, c.CourseId })
                .IsUnique(); // Prevent duplicate certificates // One certificate per course per user (Composite Unique Index)

            // Relationships (assuming navigation properties exist)
            builder.HasOne(c => c.UserProfile)
                .WithMany()
                .HasForeignKey(c => c.UserProfileId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Course)
                .WithMany()
                .HasForeignKey(c => c.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}