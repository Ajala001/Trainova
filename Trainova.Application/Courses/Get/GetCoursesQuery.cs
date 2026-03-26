using MediatR;
using Trainova.Application.Common.DTOs;

namespace Trainova.Application.Courses.Get
{
    public record GetCoursesQuery() : IRequest<List<CourseDto>>;
}
