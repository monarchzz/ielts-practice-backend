using Application.Authentication.Common;
using Domain.Enums;
using ErrorOr;
using MediatR;

namespace Application.Authentication.Commands.UserRegister;

public class UserRegisterCommand : IRequest<ErrorOr<AuthenticationResult>>
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public Gender Gender { get; set; }

    public DateTime DateOfBirth { get; set; }
}