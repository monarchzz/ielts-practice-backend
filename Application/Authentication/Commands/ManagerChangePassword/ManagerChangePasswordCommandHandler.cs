using Application.Authentication.Commands.UserChangePassword;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Application.Authentication.Commands.ManagerChangePassword;

public class ManagerChangePasswordCommandHandler : IRequestHandler<ManagerChangePasswordCommand, ErrorOr<Updated>>
{
    private readonly IPasswordHelper _passwordHelper;
    private readonly IManagerRepository _managerRepository;

    public ManagerChangePasswordCommandHandler(IPasswordHelper passwordHelper, IUserRepository userRepository,
        IManagerRepository managerRepository)
    {
        _passwordHelper = passwordHelper;
        _managerRepository = managerRepository;
    }

    public async Task<ErrorOr<Updated>> Handle(ManagerChangePasswordCommand command,
        CancellationToken cancellationToken)
    {
        var manager = await _managerRepository.GetByIdAsync(command.Id);

        if (manager == null) return Errors.User.NotExists;
        if (!_passwordHelper.VerifyHashedPassword(manager.Password, command.CurrentPassword))
        {
            return Errors.User.CurrentPasswordIsIncorrect;
        }

        manager.Password = _passwordHelper.HashPassword(command.NewPassword);

        _managerRepository.Update(manager);
        await _managerRepository.SaveChangesAsync();

        return Result.Updated;
    }
}