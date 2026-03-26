using MediatR;
using Trainova.Application.Common.DTOs;
using Trainova.Application.Common.Interfaces;
using Trainova.Application.Common.Models;

namespace Trainova.Application.Authentication.Login
{
    public class LoginCommandHandler(IIdentityService identityService, ITokenService tokenService) : IRequestHandler<LoginCommand, Result<AuthResponse>>
    {
        public async Task<Result<AuthResponse>> Handle(LoginCommand request, CancellationToken ct)
        {
           var result = await identityService.LoginAsync(request.Email, request.Password);
            if(!result.IsSuccess)
                return Result<AuthResponse>.Failure(result.Error);

            var token = tokenService.GenerateToken(result.UserId, request.Email);

            return Result<AuthResponse>.Success(new AuthResponse
            {
                Token = token,
                Email = request.Email!
            });
        }
    }
}
