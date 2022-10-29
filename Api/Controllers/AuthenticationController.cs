using Api.Dtos.Authentication;
using Application.Authentication.Commands.ManagerChangePassword;
using Application.Authentication.Commands.UserChangePassword;
using Application.Authentication.Commands.UserRegister;
using Application.Authentication.Queries.ManagerLogin;
using Application.Authentication.Queries.ManagerRefreshToken;
using Application.Authentication.Queries.UserLogin;
using Application.Authentication.Queries.UserRefreshToken;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("users/register")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(UserAuthenticationDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> UserRegister(UserRegisterDto dto)
    {
        var command = _mapper.Map<UserRegisterCommand>(dto);
        var authResult = await _mediator.Send(command);

        return authResult.Match(
            success => Ok(_mapper.Map<UserAuthenticationDto>(success)),
            Problem);
    }

    [HttpPost("users/login")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(UserAuthenticationDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> UserLogin(LoginDto dto)
    {
        var query = _mapper.Map<UserLoginQuery>(dto);
        var authResult = await _mediator.Send(query);

        return authResult.Match(
            success => Ok(_mapper.Map<UserAuthenticationDto>(success)),
            Problem);
    }

    [HttpPost("users/refresh-token")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(UserAuthenticationDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> UserRefreshToken(RefreshTokenDto dto)
    {
        var query = _mapper.Map<UserRefreshTokenQuery>(dto);
        var authResult = await _mediator.Send(query);

        return authResult.Match(
            success => Ok(_mapper.Map<UserAuthenticationDto>(success)),
            Problem);
    }

    [HttpPut("users/change-password")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UserChangePassword(ChangePasswordDto dto)
    {
        var command = _mapper.Map<UserChangePasswordCommand>(dto);
        command.Id = Guid.Parse(CurrentUserId!);
        var result = await _mediator.Send(command);

        return result.Match(_ => NoContent(), Problem);
    }

    [HttpPost("managers/login")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(UserAuthenticationDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> ManagerLogin(LoginDto dto)
    {
        var query = _mapper.Map<ManagerLoginQuery>(dto);
        var authResult = await _mediator.Send(query);

        return authResult.Match(
            success => Ok(_mapper.Map<ManagerAuthenticationDto>(success)),
            Problem);
    }

    [HttpPut("managers/change-password")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> ManagerChangePassword(ChangePasswordDto dto)
    {
        var command = _mapper.Map<ManagerChangePasswordCommand>(dto);
        command.Id = Guid.Parse(CurrentUserId!);
        var result = await _mediator.Send(command);

        return result.Match(_ => NoContent(), Problem);
    }

    [HttpPost("managers/refresh-token")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(UserAuthenticationDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> ManagerRefreshToken(RefreshTokenDto dto)
    {
        var query = _mapper.Map<ManagerRefreshTokenQuery>(dto);
        var authResult = await _mediator.Send(query);

        return authResult.Match(
            success => Ok(_mapper.Map<ManagerAuthenticationDto>(success)),
            Problem);
    }
}