using Application.Users.Common;
using ErrorOr;
using MediatR;

namespace Application.Users.Queries.Profile;

public record ProfileQuery(Guid Id) : IRequest<ErrorOr<UserResult>>;