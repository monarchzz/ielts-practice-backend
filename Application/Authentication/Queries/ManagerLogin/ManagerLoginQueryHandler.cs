using Application.Authentication.Common;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Application.Authentication.Queries.ManagerLogin;

public class ManagerLoginQueryHandler : IRequestHandler<ManagerLoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IPasswordHelper _passwordHelper;
    private readonly IManagerRepository _managerRepository;

    public ManagerLoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IPasswordHelper passwordHelper,
        IManagerRepository managerRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _passwordHelper = passwordHelper;
        _managerRepository = managerRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(ManagerLoginQuery query,
        CancellationToken cancellationToken)
    {
        if (await _managerRepository.GetByEmailAsync(query.Username) is not { } manager)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (!_passwordHelper.VerifyHashedPassword(manager.Password, query.Password))
        {
            return Errors.Authentication.InvalidCredentials;
        }

        var token = _jwtTokenGenerator.GenerateToken(manager);
        var refreshToken = _jwtTokenGenerator.GenerateRefreshToken(manager);

        return new AuthenticationResult()
        {
            Token = token,
            RefreshToken = refreshToken,
            Manager = manager
        };
    }
}