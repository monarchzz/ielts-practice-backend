using Application.Common.Interfaces.Persistence;
using Application.Users.Common;
using Domain.Common.Errors;
using MediatR;
using ErrorOr;
using MapsterMapper;

namespace Application.Users.Queries.GetUser;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ErrorOr<UserResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<UserResult>> Handle(GetUserQuery query, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(query.Id);

        if (user == null) return Errors.User.NotExists;

        return _mapper.Map<UserResult>(user);
    }
}