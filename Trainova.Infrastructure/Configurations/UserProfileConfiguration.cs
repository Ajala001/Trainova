using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trainova.Domain.UserProfiles;

namespace Trainova.Infrastructure.Configurations
{
    public class UserProfileConfiguration : BaseEntityConfiguration<UserProfile>
    {
        public override void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            // Table
            builder.ToTable("UserProfiles");

            // Properties
            builder.Property(p => p.FullName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(p => p.IdentityUserId)
                .IsRequired();

            builder.Property(p => p.CreatedAt)
                .HasDefaultValueSql("NOW()");

            // Indexes
            builder.HasIndex(p => p.IdentityUserId)
                .IsUnique(); // One profile per identity user

            builder.HasIndex(p => p.Email);

            // Relationships
            builder.HasMany(p => p.Enrollments)
                .WithOne(e => e.UserProfile)
                .HasForeignKey(e => e.UserProfileId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}