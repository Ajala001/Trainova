using Trainova.Domain.Common;
using Trainova.Domain.Enrollments;

namespace Trainova.Domain.Users
{
    public class Person : BaseEntity
    {
        public string FirstName { get; private set; } 
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public DateOnly DateOfBirth { get; private set; }
        public bool IsActive { get; private set; }

        private readonly List<Enrollment> _enrollments = [];
        public IReadOnlyCollection<Enrollment> Enrollments => _enrollments;

        private Person() { }
        public void Deactivate()
        {
            IsActive = false;
        }
    }

}
