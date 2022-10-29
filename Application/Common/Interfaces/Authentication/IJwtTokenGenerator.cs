using Domain.Entities;

namespace Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);

    string GenerateToken(Manager manager);

    string GenerateRefreshToken(User user);

    string GenerateRefreshToken(Manager manager);

    Guid? VerifyToken(string refreshToken);
}