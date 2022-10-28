using Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Application.Authentication.Queries.RefreshToken;

public class RefreshTokenQuery : IRequest<ErrorOr<AuthenticationResult>>
{
    public string RefreshToken { get; set; } = null!;
}