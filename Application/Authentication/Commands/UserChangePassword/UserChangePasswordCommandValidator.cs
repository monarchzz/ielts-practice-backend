using FluentValidation;

namespace Application.Authentication.Commands.UserChangePassword;

public class UserChangePasswordCommandValidator : AbstractValidator<UserChangePasswordCommand>
{
    public UserChangePasswordCommandValidator()
    {
        RuleFor(x => x.NewPassword).NotEmpty().MinimumLength(6);
        RuleFor(x => x.CurrentPassword).NotEmpty().MinimumLength(6);
    }
}