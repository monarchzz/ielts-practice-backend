using FluentValidation;

namespace Application.Authentication.Queries.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(x => x.Username).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}