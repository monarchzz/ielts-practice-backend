using Domain.Enums;

namespace Api.Dtos.Authentication;

public class AuthenticationDto
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public Gender Gender { get; set; }

    public string Token { get; set; } = null!;

    public string RefreshToken { get; set; } = null!;
}