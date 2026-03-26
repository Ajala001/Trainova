using Trainova.Domain.Common;

namespace Trainova.Domain.Attendances
{
    public class Attendance(Guid trainingId, Guid personId, DateOnly date) : BaseEntity
    {
        public Guid TrainingId { get; private set; } = trainingId;
        public Guid PersonId { get; private set; } = personId;

        public DateOnly Date { get; private set; } = date;

        public bool IsPresent { get; private set; } = false;

        public void MarkPresent()
        {
            IsPresent = true;
        }
    }

}
