using Microsoft.AspNetCore.Identity;

namespace Trainova.Persistence.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public Guid PersonId { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
    }
}
