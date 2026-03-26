using MediatR;
using Trainova.Application.Common.DTOs;
using Trainova.Application.Common.Models;

namespace Trainova.Application.Authentication.Register
{
    public record RegisterCommand(
    string FullName,
    string Email,
    string Password,
    string PhoneNumber,
    DateTime DateOfBirth
) : IRequest<Result<AuthResponse>>;
}
