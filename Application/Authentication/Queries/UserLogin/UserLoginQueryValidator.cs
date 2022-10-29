using FluentValidation;

namespace Application.Authentication.Queries.UserLogin;

public class UserLoginQueryValidator : AbstractValidator<UserLoginQuery>
{
    public UserLoginQueryValidator()
    {
        RuleFor(x => x.Username).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}