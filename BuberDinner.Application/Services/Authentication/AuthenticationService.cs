using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
	private readonly IJwtTokenGenerator _jwtTokenGenerator;
	private readonly IUserRepository _userRepository;

	public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
	{
		_jwtTokenGenerator = jwtTokenGenerator;
		_userRepository = userRepository;
	}

	public AuthenticationResult Login(string email, string password)
	{
		// 1. Validate user is exists
		if (_userRepository.GetUserByEmail(email) is not User user)
		{
			throw new Exception("Invalid credentials");
		}

		// 2. Validate the password is correct
		if (user.Password != password)
		{
			throw new Exception("Invalid credentials");
		}

		// 3. Generate token
		var token = _jwtTokenGenerator.GenerateToken(user);

		return new AuthenticationResult(user, token);
	}

	public AuthenticationResult Register(string firstName, string lastName, string email, string password)
	{
		// 1. Check if the user already exists
		if (_userRepository.GetUserByEmail(email) is not null)
		{
			throw new Exception("User with given email address is already exists");
		}

		// 2. Create new user
		var user = new User
		{
			FirstName = firstName,
			LastName = lastName,
			Email = email,
			Password = password
		};

		_userRepository.Add(user);

		// 3. Generate token
		var token = _jwtTokenGenerator.GenerateToken(user);

		return new AuthenticationResult(user, token);
	}
}