using Application.Authentication.Commands.UserChangePassword;
using FluentValidation;

namespace Application.Authentication.Commands.ManagerChangePassword;

public class ManagerChangePasswordCommandValidator : AbstractValidator<UserChangePasswordCommand>
{
    public ManagerChangePasswordCommandValidator()
    {
        RuleFor(x => x.CurrentPassword).NotEmpty().MinimumLength(6);
    }
}