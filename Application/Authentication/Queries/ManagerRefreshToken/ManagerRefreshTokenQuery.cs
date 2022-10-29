using Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Application.Authentication.Queries.ManagerRefreshToken;

public class ManagerRefreshTokenQuery : IRequest<ErrorOr<AuthenticationResult>>
{
    public string RefreshToken { get; set; } = null!;
}