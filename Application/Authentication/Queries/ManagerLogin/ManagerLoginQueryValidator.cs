using Application.Authentication.Queries.UserLogin;
using FluentValidation;

namespace Application.Authentication.Queries.ManagerLogin;

public class ManagerLoginQueryValidator : AbstractValidator<ManagerLoginQuery>
{
    public ManagerLoginQueryValidator()
    {
        RuleFor(x => x.Username).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).NotEmpty();
    }
}