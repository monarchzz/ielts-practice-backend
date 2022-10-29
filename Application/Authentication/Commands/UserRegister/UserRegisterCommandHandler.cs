using Application.Authentication.Common;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.Entities;
using ErrorOr;
using MediatR;

namespace Application.Authentication.Commands.UserRegister;

public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IPasswordHelper _passwordHelper;
    private readonly IUserRepository _userRepository;

    public UserRegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IPasswordHelper passwordHelper,
        IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _passwordHelper = passwordHelper;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(UserRegisterCommand command,
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
            IsActive = true
        };

        await _userRepository.AddAsync(user);
        await _userRepository.SaveChangesAsync();

        var token = _jwtTokenGenerator.GenerateToken(user);
        var refreshToken = _jwtTokenGenerator.GenerateRefreshToken(user);

        return new AuthenticationResult()
        {
            Token = token,
            RefreshToken = refreshToken,
            User = user
        };
    }
}