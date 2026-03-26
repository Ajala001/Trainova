using MediatR;
using Trainova.Application.Common.DTOs;
using Trainova.Application.Common.Models;

public record LoginCommand(
    string Email,
    string Password
) : IRequest<Result<AuthResponse>>;