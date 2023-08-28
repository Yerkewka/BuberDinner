using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
	private readonly IJwtTokenGenerator _jwtTokenGenerator;

	public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
	{
		_jwtTokenGenerator = jwtTokenGenerator;
	}

	public AuthenticationResult Login(string email, string password)
	{
		return new AuthenticationResult(Guid.NewGuid(), "Yerkebulan", "Serikbayev", email, "Token");
	}

	public AuthenticationResult Register(string firstName, string lastName, string email, string password)
	{
		// Check if the user already exists

		// Create new user
		var userId = Guid.NewGuid();

		// Generate token
		var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

		return new AuthenticationResult(userId, firstName, lastName, email, token);
	}
}