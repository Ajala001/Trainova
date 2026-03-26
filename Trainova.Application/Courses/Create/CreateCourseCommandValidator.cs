using FluentValidation;

namespace Trainova.Application.Courses.Create
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Course title is required");
            RuleFor(x => x.Price).GreaterThan(-1).WithMessage("Price must not be negative");
        }
    }
}
