using Application.Authentication.Common;
using Domain.Enums;
using MediatR;
using ErrorOr;

namespace Application.Authentication.Commands;

public class RegisterCommand : IRequest<ErrorOr<AuthenticationResult>>
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public Gender Gender { get; set; }

    public DateTime DateOfBirth { get; set; }
}