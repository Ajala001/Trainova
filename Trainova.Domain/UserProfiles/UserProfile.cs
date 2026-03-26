using Trainova.Domain.Common;
using Trainova.Domain.Enrollments;

namespace Trainova.Domain.UserProfiles
{
    public class UserProfile : BaseEntity
    {
        public Guid IdentityUserId { get; private set; }
        public string FullName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string PhoneNumber { get; private set; } = string.Empty;
        public DateTime DateOfBirth { get; private set; }

        private readonly List<Enrollment> _enrollments = new();
        public IReadOnlyCollection<Enrollment> Enrollments => _enrollments.AsReadOnly();

        public bool IsActive { get; private set; }

        private UserProfile() { } // For EF

        public UserProfile(
            Guid identityUserId,
            string fullName,
            string email,
            string phoneNumber,
            DateTime dateOfBirth)
        {
            IdentityUserId = identityUserId;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            DateOfBirth = dateOfBirth;
            IsActive = true;
        }

        public void UpdateProfile(string fullName, string phoneNumber)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }

        public void Deactivate()
        {
            IsActive = false;
        }
    }

}
