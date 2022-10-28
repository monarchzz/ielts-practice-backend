using Application.Users.Common;
using MediatR;
using ErrorOr;

namespace Application.Users.Queries.GetUser;

public class GetUserQuery : IRequest<ErrorOr<UserResult>>
{
    public Guid Id { get; set; }
}