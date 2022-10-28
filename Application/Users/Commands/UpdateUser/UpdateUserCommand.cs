using Application.Users.Common;
using Domain.Enums;
using ErrorOr;
using MediatR;

namespace Application.Users.Commands.UpdateUser;

public class UpdateUserCommand : IRequest<ErrorOr<Updated>>
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public Gender Gender { get; set; }

    public DateTime DateOfBirth { get; set; }

    public bool IsActive { get; set; }
}