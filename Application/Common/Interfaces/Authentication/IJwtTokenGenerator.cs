using Domain.Entities;

namespace Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);

    string GenerateToken(Censor censor);

    string GenerateRefreshToken(User user);

    string GenerateRefreshToken(Censor censor);

    Guid? VerifyToken(string refreshToken);
}