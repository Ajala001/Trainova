using MediatR;
using Microsoft.EntityFrameworkCore;
using Trainova.Application.Common.DTOs;
using Trainova.Application.Common.Interfaces;
using Trainova.Domain.Courses;

namespace Trainova.Application.Courses.Get
{
    public class GetCoursesQueryHandler(ITrainovaDbContext context) : IRequestHandler<GetCoursesQuery, List<CourseDto>>
    {

        public async Task<List<CourseDto>> Handle(GetCoursesQuery request, CancellationToken ct)
        {
            return await context.Courses
                .Where(c => c.Status == CourseStatus.Published)
                .Select(c => new CourseDto
                {
                    Id = c.Id,
                    Title = c.Title,
                    Price = c.Price
                })
                .ToListAsync(ct);
        }
    }
}
