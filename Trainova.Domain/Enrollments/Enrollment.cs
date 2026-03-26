using Trainova.Domain.Common;
using Trainova.Domain.Courses;
using Trainova.Domain.UserProfiles;

namespace Trainova.Domain.Enrollments
{
    public class Enrollment(Guid courseId, Guid userProfileId) : BaseEntity
    {
        public Guid CourseId { get; private set; } = courseId;
        public Guid UserProfileId { get; private set; } = userProfileId;
        public Course Course { get; private set; }
        public UserProfile UserProfile { get; private set; }
        public EnrollmentStatus Status { get; private set; } = EnrollmentStatus.PendingPayment;
        public DateTime? CompletedAt { get; private set; }
        public DateTime EnrolledAt { get; private set; } = DateTime.UtcNow;

        public void Complete()
        {
            if (Status != EnrollmentStatus.Active)
                throw new InvalidOperationException("Only active enrollments can be completed.");

            Status = EnrollmentStatus.Completed;
            CompletedAt = DateTime.UtcNow;
        }

        public void Activate()
        {
            if (Status != EnrollmentStatus.PendingPayment)
                throw new InvalidOperationException("Enrollment cannot be activated.");

            Status = EnrollmentStatus.Active;
        }

        public void Cancel()
        {
            if (Status == EnrollmentStatus.Cancelled)
                throw new InvalidOperationException("Already cancelled.");

            Status = EnrollmentStatus.Cancelled;
        }

    }
}




