using Api.Dtos.Attachment;
using Domain.Enums;

namespace Api.Dtos.Users;

public class UserDto
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public Gender Gender { get; set; }

    public DateTime DateOfBirth { get; set; }

    public bool IsActive { get; set; }

    public AttachmentDto Avatar { get; set; } = null!;
};