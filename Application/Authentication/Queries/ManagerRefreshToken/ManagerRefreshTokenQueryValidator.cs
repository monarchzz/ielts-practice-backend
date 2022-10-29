using FluentValidation;

namespace Application.Authentication.Queries.ManagerRefreshToken;

public class ManagerRefreshTokenQueryValidator : AbstractValidator<ManagerRefreshTokenQuery>
{
    public ManagerRefreshTokenQueryValidator()
    {
        RuleFor(x => x.RefreshToken).NotEmpty();
    }
}