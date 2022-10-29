using Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Application.Authentication.Queries.ManagerLogin;

public class ManagerLoginQuery : IRequest<ErrorOr<AuthenticationResult>>
{
    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}