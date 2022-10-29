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
        var user = await _managerRepository.GetByIdAsync(command.Id);
        if (user == null) return Errors.User.NotExists;

        user.Password = _passwordHelper.HashPassword(command.NewPassword);

        _managerRepository.Update(user);
        await _managerRepository.SaveChangesAsync();

        return Result.Updated;
    }
}