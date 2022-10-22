using Domain.Enums;

namespace Application.Users.Common;

public record UserResult(Guid Id, string FirstName, string LastName, string Email, Gender Gender);