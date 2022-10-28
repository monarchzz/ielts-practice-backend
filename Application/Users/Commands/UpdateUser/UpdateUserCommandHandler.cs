using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Application.Users.Commands.CreateUser;
using Application.Users.Common;
using Domain.Common.Errors;
using Domain.Entities;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace Application.Users.Commands.UpdateUser;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ErrorOr<Updated>>
{
    private readonly IPasswordHelper _passwordHelper;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IPasswordHelper passwordHelper, IUserRepository userRepository, IMapper mapper)
    {
        _passwordHelper = passwordHelper;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<Updated>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(command.Id);
        if (user == null) return Errors.User.NotExists;

        var userWithEmail = await _userRepository.GetByEmailAsync(command.Email);
        if (userWithEmail != null && user.Id != userWithEmail.Id) return Errors.User.DuplicateEmail;

        _mapper.Map(command, user);
        user.Password = _passwordHelper.HashPassword(command.Password);

        _userRepository.Update(user);
        await _userRepository.SaveChangesAsync();

        return Result.Updated;
    }
}