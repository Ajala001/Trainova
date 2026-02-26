using Trainova.Domain.Common;

namespace Trainova.Domain.Enrollments
{
    public class Enrollment(Guid userId, Guid trainingId) : BaseEntity
    {
        public Guid UserId { get; private set; } = userId;
        public Guid TrainingId { get; private set; } = trainingId;

        public EnrollmentStatus Status { get; private set; } = EnrollmentStatus.PendingPayment;

        public DateTime EnrolledAt { get; private set; } = DateTime.UtcNow;

        public void Activate()
        {
            Status = EnrollmentStatus.Active;
        }
    }

}
