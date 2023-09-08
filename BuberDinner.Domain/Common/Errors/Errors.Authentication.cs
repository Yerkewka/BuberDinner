
using ErrorOr;

namespace BuberDinner.Domain.Common.Errors;

public static partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials = Error.Failure(code: "User.InvalidCredentials", description: "Invalid credentials.");
    }
}