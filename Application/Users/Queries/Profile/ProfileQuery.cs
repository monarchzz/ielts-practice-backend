using Application.Users.Common;
using ErrorOr;
using MediatR;

namespace Application.Users.Queries.Profile;

public class ProfileQuery : IRequest<ErrorOr<UserResult>>
{
    public Guid Id { get; set; }
}