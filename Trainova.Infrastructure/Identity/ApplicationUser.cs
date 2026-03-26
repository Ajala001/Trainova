using Microsoft.AspNetCore.Identity;

namespace Trainova.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public bool IsActive { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
