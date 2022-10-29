using Application.Authentication.Commands;
using Application.Common.Interfaces.Persistence;
using FluentValidation;

namespace Application.Users.Commands.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator(IAttachmentRepository attachmentRepository, IUserRepository userRepository)
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.DateOfBirth).LessThan(DateTime.Now)
            .WithMessage("Date of birth must be in the past");

        RuleFor(x => x.AvatarId)
            .MustAsync(async (id, _) => id == null || await attachmentRepository.ExistsAsync(at => at.Id == id))
            .WithMessage("Avatar does not exist");

        RuleFor(x => x.AvatarId)
            .MustAsync(async (id, _) =>
            {
                return id == null || !await userRepository.ExistsAsync(user => user.AvatarId == id);
            })
            .WithMessage("Avatar is already assigned to another user");
    }
}