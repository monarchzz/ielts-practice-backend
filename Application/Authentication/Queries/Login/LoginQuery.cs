using Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Application.Authentication.Queries.Login;

public class LoginQuery : IRequest<ErrorOr<AuthenticationResult>>
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}