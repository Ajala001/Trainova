using Trainova.Domain.Common;

namespace Trainova.Domain.Certificates
{
    public class Certificate(Guid userId, Guid trainingId, string certificateNumber) : BaseEntity
    {
        public Guid UserId { get; private set; } = userId;
        public Guid TrainingId { get; private set; } = trainingId;
        public string CertificateNumber { get; private set; } = certificateNumber;
        public DateTime IssuedDate { get; private set; } = DateTime.UtcNow;
        public bool IsValid { get; private set; } = true;

        public void Revoke()
        {
            IsValid = false;
        }
    }

}
