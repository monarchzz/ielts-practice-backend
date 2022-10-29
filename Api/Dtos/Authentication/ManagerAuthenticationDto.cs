using Domain.Enums;

namespace Api.Dtos.Authentication;

public class ManagerAuthenticationDto
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public bool IsActive { get; set; }

    public string Token { get; set; } = null!;

    public string RefreshToken { get; set; } = null!;
}