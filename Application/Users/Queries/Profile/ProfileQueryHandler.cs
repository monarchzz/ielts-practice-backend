using Application.Common.Interfaces.Persistence;
using Application.Users.Common;
using Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace Application.Users.Queries.Profile;

public class ProfileQueryHandler : IRequestHandler<ProfileQuery, ErrorOr<UserResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public ProfileQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<UserResult>> Handle(ProfileQuery query, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByIdAsync(query.Id);

        if (user == null) return Errors.User.NotExists;

        return _mapper.Map<UserResult>(user);
    }
}