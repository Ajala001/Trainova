using Microsoft.EntityFrameworkCore;
using Trainova.Domain.Certificates;
using Trainova.Domain.Courses;
using Trainova.Domain.Enrollments;
using Trainova.Domain.UserProfiles;

namespace Trainova.Application.Common.Interfaces
{
    public interface ITrainovaDbContext
    {
        DbSet<UserProfile> UserProfiles { get; }
        DbSet<Course> Courses { get; }
        DbSet<Enrollment> Enrollments { get; }
        DbSet<Certificate> Certificates { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
