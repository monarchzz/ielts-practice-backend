using FluentValidation;

namespace Application.Authentication.Queries.UserRefreshToken;

public class UserRefreshTokenQueryValidator : AbstractValidator<UserRefreshTokenQuery>
{
    public UserRefreshTokenQueryValidator()
    {
        RuleFor(x => x.RefreshToken).NotEmpty();
    }
}