using Trainova.Domain.Common;
using Trainova.Domain.Payment;

namespace Trainova.Domain.Payments
{
    public class Payment : BaseEntity
    {
        public Guid UserId { get; private set; }
        public Guid TrainingId { get; private set; }
        public decimal Amount { get; private set; }
        public PaymentStatus Status { get; private set; }
        public string Reference { get; private set; } = string.Empty;
        public DateTime? PaidAt { get; private set; }

        public void MarkAsPaid()
        {
            Status = PaymentStatus.Paid;
            PaidAt = DateTime.UtcNow;
        }
    }

}
