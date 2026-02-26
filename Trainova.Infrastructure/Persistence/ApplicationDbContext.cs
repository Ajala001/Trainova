using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trainova.Domain.Attendances;
using Trainova.Domain.Certificates;
using Trainova.Domain.Enrollments;
using Trainova.Domain.Examinations;
using Trainova.Domain.Payments;
using Trainova.Domain.Results;
using Trainova.Domain.Trainings;
using Trainova.Domain.Users;
using Trainova.Infrastructure.Identity;

namespace Trainova.Infrastructure.Persistence
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Examination> Examinations { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Training> Trainings { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
