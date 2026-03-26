using MediatR;
using Trainova.Application.Common.Interfaces;
using Trainova.Application.Common.Models;
using Trainova.Domain.Courses;

namespace Trainova.Application.Courses.Create
{
    public class CreateCourseCommandHandler(ITrainovaDbContext context,
            ICurrentUserService currentUser)
    : IRequestHandler<CreateCourseCommand, Result<Guid>>
    {
        public async Task<Result<Guid>> Handle(CreateCourseCommand request, CancellationToken ct)
        {
            if (!currentUser.IsAuthenticated)
                return Result<Guid>.Failure("Unauthorized");

            var course = new Course(
                request.Title,
                request.Description,
                request.Price
            );

            context.Courses.Add(course);
            await context.SaveChangesAsync(ct);

            return Result<Guid>.Success(course.Id);
        }
    }
}
