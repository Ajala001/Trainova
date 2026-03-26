using MediatR;
using Trainova.Application.Common.Models;

namespace Trainova.Application.Courses.Create
{
        public record CreateCourseCommand(
        string Title,
        string Description,
        decimal Price
    ) : IRequest<Result<Guid>>;
}
