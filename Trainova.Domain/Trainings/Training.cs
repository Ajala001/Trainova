using Trainova.Domain.Attendances;
using Trainova.Domain.Common;
using Trainova.Domain.Enrollments;
using Trainova.Domain.Users;

namespace Trainova.Domain.Trainings
{
    public class Training : BaseEntity
    {
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public decimal Fee { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public int Capacity { get; private set; }
        public TrainingStatus Status { get; private set; }

        private readonly List<Enrollment> _enrollments = [];
        public IReadOnlyCollection<Enrollment> Enrollments => _enrollments;

        private readonly List<Attendance> _attendances = [];
        public IReadOnlyCollection<Attendance> Attendances => _attendances;

        public void Enroll(Person user)
        {
            if (_enrollments.Count >= Capacity)
                throw new Exception("Training is full");

            _enrollments.Add(new Enrollment(user.Id, Id));
        }
    }

}
