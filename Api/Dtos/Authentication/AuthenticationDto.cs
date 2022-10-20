using Domain.Enums;

namespace Api.Dtos.Authentication;

public record AuthenticationDto(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    Gender Gender,
    string Token,
    string RefreshToken
);