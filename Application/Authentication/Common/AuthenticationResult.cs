using Domain.Entities;

namespace Application.Authentication.Common;

public class AuthenticationResult
{
    public User? User { get; set; }

    public Manager? Manager { get; set; }

    public string Token { get; set; } = null!;

    public string RefreshToken { get; set; } = null!;
};