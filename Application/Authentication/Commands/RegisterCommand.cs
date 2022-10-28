using Application.Authentication.Common;
using Domain.Enums;
using MediatR;
using ErrorOr;

namespace Application.Authentication.Commands;

public class RegisterCommand : IRequest<ErrorOr<AuthenticationResult>>
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public Gender Gender { get; set; }

    public RegisterCommand(string firstName, string lastName, string email, string password, Gender gender)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        Gender = gender;
    }
}