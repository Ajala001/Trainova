using MediatR;
using Trainova.Application.Common.Models;

namespace Trainova.Application.Enrollments.Enroll
{
    public record EnrollUserCommand(Guid CourseId)
    : IRequest<Result<Guid>>;
}
