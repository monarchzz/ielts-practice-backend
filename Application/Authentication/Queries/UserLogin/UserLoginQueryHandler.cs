using Application.Authentication.Common;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Application.Authentication.Queries.UserLogin;

public class UserLoginQueryHandler : IRequestHandler<UserLoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IPasswordHelper _passwordHelper;
    private readonly IUserRepository _userRepository;

    public UserLoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IPasswordHelper passwordHelper,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _passwordHelper = passwordHelper;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(UserLoginQuery query, CancellationToken cancellationToken)
    {
        if (await _userRepository.GetByEmailAsync(query.Username) is not { } user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (!_passwordHelper.VerifyHashedPassword(user.Password, query.Password))
        {
            return Errors.Authentication.InvalidCredentials;
        }

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