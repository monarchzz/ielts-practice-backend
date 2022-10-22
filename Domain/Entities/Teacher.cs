using Domain.Enums;

namespace Domain.Entities;

public class Teacher
{
    public Guid Id { get; set; }

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public Gender Gender { get; set; }

    public string IdentityCard { get; set; } = null!;
}