using MediatR;
using Microsoft.EntityFrameworkCore;
using Trainova.Application.Common.Interfaces;
using Trainova.Application.Common.Models;
using Trainova.Domain.Enrollments;

namespace Trainova.Application.Enrollments.Enroll
{
    public class EnrollUserCommandHandler(
        ITrainovaDbContext context,
        ICurrentUserService currentUser)
        : IRequestHandler<EnrollUserCommand, Result<Guid>>
    {
        public async Task<Result<Guid>> Handle(EnrollUserCommand request, CancellationToken ct)
        {
            if (!currentUser.IsAuthenticated)
                return Result<Guid>.Failure("Unauthorized");

            var profile = await context.UserProfiles
                .FirstOrDefaultAsync(p => p.IdentityUserId == currentUser.UserId, ct);

            if (profile == null)
                return Result<Guid>.Failure("Profile not found");

            var exists = await context.Enrollments
                .AnyAsync(e => e.CourseId == request.CourseId && e.UserProfileId == profile.Id, ct);

            if (exists)
                return Result<Guid>.Failure("Already enrolled");

            var enrollment = new Enrollment(request.CourseId, profile.Id);

            context.Enrollments.Add(enrollment);
            await context.SaveChangesAsync(ct);

            return Result<Guid>.Success(enrollment.Id);
        }
    }
}
