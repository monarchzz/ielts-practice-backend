using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Application.Users.Common;
using Domain.Common.Errors;
using Domain.Entities;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ErrorOr<UserResult>>
{
    private readonly IPasswordHelper _passwordHelper;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IPasswordHelper passwordHelper, IUserRepository userRepository, IMapper mapper)
    {
        _passwordHelper = passwordHelper;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<UserResult>> Handle(CreateUserCommand command,
        CancellationToken cancellationToken)
    {
        if (await _userRepository.GetByEmailAsync(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = _passwordHelper.HashPassword(command.Password),
            Gender = command.Gender,
            DateOfBirth = command.DateOfBirth,
            IsActive = command.IsActive
        };

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        return _mapper.Map<UserResult>(user);
    }
}