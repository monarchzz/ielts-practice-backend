using Application.Authentication.Common;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Application.Authentication.Queries.UserRefreshToken;

public class UserRefreshTokenQueryHandler : IRequestHandler<UserRefreshTokenQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public UserRefreshTokenQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(UserRefreshTokenQuery query,
        CancellationToken cancellationToken)
    {
        var userId = _jwtTokenGenerator.VerifyToken(query.RefreshToken);
        if (userId == null) return Errors.Authentication.TokenExpiredOrInvalid;

        var user = await _userRepository.GetByIdAsync(userId.Value);
        if (user == null) return Errors.Authentication.InvalidCredentials;

        var token = _jwtTokenGenerator.GenerateToken(user);
        var refreshToken = _jwtTokenGenerator.GenerateRefreshToken(user);

        return new AuthenticationResult()
        {
            Token = token,
            RefreshToken = refreshToken,
            User = user
        };
    }
}