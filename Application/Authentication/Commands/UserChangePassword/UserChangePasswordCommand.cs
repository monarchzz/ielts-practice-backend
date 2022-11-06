using Application.Authentication.Common;
using MediatR;
using ErrorOr;

namespace Application.Authentication.Commands.UserChangePassword;

public class UserChangePasswordCommand : IRequest<ErrorOr<Updated>>
{
    public Guid Id { get; set; }
    
    public string CurrentPassword { get; set; } = null!;

    public string NewPassword { get; set; } = null!;
}