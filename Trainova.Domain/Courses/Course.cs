using Trainova.Domain.Common;
using Trainova.Domain.Enrollments;

namespace Trainova.Domain.Courses
{
    public class Course : BaseEntity
    {
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public CourseStatus Status { get; private set; }
        private readonly List<Enrollment> _enrollments = new();
        public IReadOnlyCollection<Enrollment> Enrollments => _enrollments.AsReadOnly();

        private Course() { } // For EF

        public Course(
            string title,
            string description,
            decimal price)
        {
            Title = title;
            Description = description;
            Price = price;
            Status = CourseStatus.Draft;
        }

        public void Publish()
        {
            if (Status != CourseStatus.Draft)
                throw new InvalidOperationException("Only draft courses can be published.");

            Status = CourseStatus.Published;
        }
    }

}
