namespace Application.Common.Interfaces.Authentication;

public interface IPasswordHelper
{
    string HashPassword(string password);

    bool VerifyHashedPassword(string hashedPassword, string password);
}