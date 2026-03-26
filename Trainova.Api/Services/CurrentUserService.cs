using System.Security.Claims;
using Trainova.Application.Common.Interfaces;

namespace Trainova.Api.Services
{
    public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
    {
        public Guid UserId
        {
            get
            {
                var userId = httpContextAccessor.HttpContext?
                    .User?
                    .FindFirstValue(ClaimTypes.NameIdentifier);

                return userId != null ? Guid.Parse(userId) : Guid.Empty;
            }
        }

        public string Email =>
            httpContextAccessor.HttpContext?
            .User?
            .FindFirstValue(ClaimTypes.Email) ?? "system";

        public bool IsAuthenticated =>
        httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
    }
}
