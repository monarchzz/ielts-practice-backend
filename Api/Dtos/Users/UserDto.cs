using Domain.Enums;

namespace Api.Dtos.Users;

public record UserDto(Guid Id, string FirstName, string LastName, string Email, Gender Gender);