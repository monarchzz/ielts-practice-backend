using Domain.Enums;

namespace Api.Dtos.Users;

public class UpdateUserDto
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public Gender Gender { get; set; }

    public DateTime DateOfBirth { get; set; }

    public bool IsActive { get; set; }
}