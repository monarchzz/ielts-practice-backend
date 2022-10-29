using Application.Authentication.Commands.UserChangePassword;
using FluentValidation;

namespace Application.Authentication.Commands.ManagerChangePassword;

public class ManagerChangePasswordCommandValidator : AbstractValidator<UserChangePasswordCommand>
{
    public ManagerChangePasswordCommandValidator()
    {
        RuleFor(x => x.NewPassword).NotEmpty().MinimumLength(6);
    }
}