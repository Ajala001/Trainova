using Microsoft.AspNetCore.Identity;
using Trainova.Application.Common.Interfaces;

namespace Trainova.Infrastructure.Identity
{
    public class IdentityService(UserManager<ApplicationUser> userManager) : IIdentityService
    {
        public async Task<(bool IsSuccess, Guid IdentityUserId, string Error)> LoginAsync(string email, string password)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
                return (false, Guid.Empty, "Email has not been registered");

            var isConfirmed = await userManager.IsEmailConfirmedAsync(user);
            if (!isConfirmed)
                return (false, Guid.Empty, "Email has not been confirmed");

            var isValid = await userManager.CheckPasswordAsync(user, password);
            if (!isValid)
                return (false, Guid.Empty, "Invalid Credentials");

            return (true, user.Id, "Valid Credentials");
        }

        public async Task<(bool IsSuccess, Guid IdentityUserId, string Error)> RegisterAsync(string email, string password)
        {
            var existingUser = await userManager.FindByEmailAsync(email);
            if (existingUser != null)
                return (false, Guid.Empty, "Email already in use");

            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                CreatedAt = DateTime.UtcNow,
                IsActive = true
            };

            var result = await userManager.CreateAsync(user, password);
            if (!result.Succeeded)
                return (false, Guid.Empty, "Registration failed");

            return (true, user.Id, string.Empty);
        }
    }
}