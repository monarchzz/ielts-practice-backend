using Application.Authentication.Common;
using Application.Authentication.Queries.UserRefreshToken;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Application.Authentication.Queries.ManagerRefreshToken;

public class ManagerRefreshTokenQueryHandler : IRequestHandler<ManagerRefreshTokenQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IManagerRepository _managerRepository;

    public ManagerRefreshTokenQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IManagerRepository managerRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _managerRepository = managerRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(ManagerRefreshTokenQuery query,
        CancellationToken cancellationToken)
    {
        var managerId = _jwtTokenGenerator.VerifyToken(query.RefreshToken);
        if (managerId == null) return Errors.Authentication.TokenExpiredOrInvalid;

        var manager = await _managerRepository.GetByIdAsync(managerId.Value);
        if (manager == null) return Errors.Authentication.InvalidCredentials;

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