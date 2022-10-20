namespace Api.Dtos.Authentication;

public record RegisterDto(string FirstName, string LastName, string Email, string Password);