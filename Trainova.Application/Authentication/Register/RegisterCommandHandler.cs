using MediatR;
using Trainova.Application.Common.DTOs;
using Trainova.Application.Common.Interfaces;
using Trainova.Application.Common.Models;
using Trainova.Domain.UserProfiles;

namespace Trainova.Application.Authentication.Register
{
    public class RegisterCommandHandler(IIdentityService identityService, ITokenService tokenService, ITrainovaDbContext context) : IRequestHandler<RegisterCommand, Result<AuthResponse>>
    {
        public async Task<Result<AuthResponse>> Handle(RegisterCommand request, CancellationToken ct)
        {
            var result = await identityService.RegisterAsync(request.Email, request.Password);
            if (!result.IsSuccess)
                return Result<AuthResponse>.Failure(result.Error);

            var userProfile = new UserProfile(
                result.IdentityUserId,
                request.FullName,
                request.Email,
                request.PhoneNumber,
                request.DateOfBirth
            );

            context.UserProfiles.Add(userProfile);
            await context.SaveChangesAsync(ct);

            var token = tokenService.GenerateToken(userProfile.IdentityUserId, userProfile.Email);
            return Result<AuthResponse>.Success(new AuthResponse
            {
                Token = token,
                Email = userProfile.Email!
            });
        }
    }
}
