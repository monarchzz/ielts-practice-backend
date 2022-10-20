using Domain.Entities;

namespace Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);

    string GenerateRefreshToken(User user);

    Guid? VerifyToken(string refreshToken);
}