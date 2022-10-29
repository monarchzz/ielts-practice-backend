using Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Application.Authentication.Queries.UserRefreshToken;

public class UserRefreshTokenQuery : IRequest<ErrorOr<AuthenticationResult>>
{
    public string RefreshToken { get; set; } = null!;
}