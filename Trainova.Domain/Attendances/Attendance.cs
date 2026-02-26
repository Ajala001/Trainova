using Trainova.Domain.Common;

namespace Trainova.Domain.Attendances
{
    public class Attendance(Guid trainingId, Guid userId, DateOnly date) : BaseEntity
    {
        public Guid TrainingId { get; private set; } = trainingId;
        public Guid UserId { get; private set; } = userId;

        public DateOnly Date { get; private set; } = date;

        public bool IsPresent { get; private set; }

        public void MarkPresent()
        {
            IsPresent = true;
        }
    }

}
