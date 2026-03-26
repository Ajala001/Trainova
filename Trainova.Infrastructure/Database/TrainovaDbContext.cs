using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trainova.Application.Common.Interfaces;
using Trainova.Domain.Certificates;
using Trainova.Domain.Common;
using Trainova.Domain.Courses;
using Trainova.Domain.Enrollments;
using Trainova.Domain.UserProfiles;
using Trainova.Infrastructure.Identity;

namespace Trainova.Infrastructure.Database
{
    public class TrainovaDbContext(DbContextOptions<TrainovaDbContext> options,
        ICurrentUserService currentUser) : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>(options), ITrainovaDbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TrainovaDbContext).Assembly);
        }

        public DbSet<Certificate> Certificates => Set<Certificate>();
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();
        public DbSet<UserProfile> UserProfiles => Set<UserProfile>();

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<BaseEntity>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    if(currentUser.IsAuthenticated) 
                        entry.Entity.SetCreated(currentUser.Email);
                    else entry.Entity.SetCreated("system");
                }

                if (entry.State == EntityState.Modified)
                {
                    if(currentUser.IsAuthenticated) 
                        entry.Entity.SetModified(currentUser.Email);
                    else entry.Entity.SetModified("system");
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

    }


}
