using Trainova.Domain.Common;
using Trainova.Domain.Courses;
using Trainova.Domain.UserProfiles;

namespace Trainova.Domain.Certificates
{
    public class Certificate(Guid userProfileId, Guid courseId) : BaseEntity
    {
        public Guid UserProfileId { get; private set; } = userProfileId;
        public Guid CourseId { get; private set; } = courseId;
        public string CertificateCode { get; private set; } = GenerateCode();
        public DateTime IssuedDate { get; private set; } = DateTime.UtcNow;
        public CertificateStatus Status { get; private set; }
        public UserProfile UserProfile { get; private set; }
        public Course Course { get; private set; }

        public void Revoke()
        {
            Status = CertificateStatus.Revoked;
        }

        static private string GenerateCode()
        {
            return Guid.NewGuid().ToString()[..8].ToUpper();
        }
    }

}
