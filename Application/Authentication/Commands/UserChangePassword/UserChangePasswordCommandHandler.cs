using Application.Authentication.Common;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using MediatR;
using ErrorOr;

namespace Application.Authentication.Commands.UserChangePassword;

public class UserChangePasswordHandler : IRequestHandler<UserChangePasswordCommand, ErrorOr<Updated>>
{
    private readonly IPasswordHelper _passwordHelper;
    private readonly IUserRepository _userRepository;

    public UserChangePasswordHandler(IPasswordHelper passwordHelper, IUserRepository userRepository)
    {
        _passwordHelper = passwordHelper;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<Updated>> Handle(UserChangePasswordCommand command,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(command.Id);
        if (user == null) return Errors.User.NotExists;

        if (!_passwordHelper.VerifyHashedPassword(user.Password, command.CurrentPassword))
        {
            return Errors.User.CurrentPasswordIsIncorrect;
        }

        user.Password = _passwordHelper.HashPassword(command.NewPassword);

        _userRepository.Update(user);
        await _userRepository.SaveChangesAsync();

        return Result.Updated;
    }
}