using ErrorOr;
using MediatR;

namespace Application.Authentication.Commands.ManagerChangePassword;

public class ManagerChangePasswordCommand : IRequest<ErrorOr<Updated>>
{
    public Guid Id { get; set; }

    public string NewPassword { get; set; } = null!;
}