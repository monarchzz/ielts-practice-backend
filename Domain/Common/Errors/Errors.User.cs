using ErrorOr;

namespace Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail =>
            Error.Conflict(code: "User.DuplicateEmail", description: "Email is already in use.");

        public static Error NotExists =>
            Error.NotFound(code: "User.NotExists", description: "User does not exist.");

        public static Error CurrentPasswordIsIncorrect =>
            Error.Validation(code: "User.CurrentPasswordIsIncorrect", description: "Current password is incorrect.");
    }
}