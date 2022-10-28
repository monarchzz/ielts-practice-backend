using Domain.Enums;

namespace Application.Users.Common;

public class UserResult
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public Gender Gender { get; set; }
}