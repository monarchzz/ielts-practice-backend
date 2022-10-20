using Application.Authentication.Common;
using Domain.Enums;
using MediatR;
using ErrorOr;

namespace Application.Authentication.Commands;

public record RegisterCommand
    (string FirstName, string LastName, string Email, string Password, Gender Gender) : IRequest<ErrorOr<AuthenticationResult>>;