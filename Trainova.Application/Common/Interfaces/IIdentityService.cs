namespace Trainova.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<(bool IsSuccess, Guid IdentityUserId, string Error)> RegisterAsync(string email, string password);
        Task<(bool IsSuccess, Guid IdentityUserId, string Error)> LoginAsync(string email, string password);
    }
}
