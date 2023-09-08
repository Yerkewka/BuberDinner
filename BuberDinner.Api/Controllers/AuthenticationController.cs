using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Application.Features.Authentication.Common;
using BuberDinner.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
	private readonly ISender _sender;
	private readonly IMapper _mapper;

	public AuthenticationController(ISender sender, IMapper mapper)
	{
		_sender = sender;
		_mapper = mapper;
	}

	[HttpPost("register")]
	public async Task<IActionResult> Register(RegisterRequest request, CancellationToken ct = default)
	{
		var command = _mapper.Map<RegisterCommand>(request);

		var authResult = await _sender.Send(command, ct);

		return authResult.Match(
			result => Ok(_mapper.Map<AuthenticationResponse>(result)),
			Problem
		);
	}

	[HttpPost("login")]
	public async Task<IActionResult> Login(LoginRequest request, CancellationToken ct = default)
	{
		var query = _mapper.Map<LoginQuery>(request);

		var authResult = await _sender.Send(query, ct);

		return authResult.Match(
			result => Ok(_mapper.Map<AuthenticationResponse>(result)),
			Problem
		);
	}
}