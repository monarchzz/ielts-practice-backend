using Api.Dtos.Authentication;
using Application.Authentication.Commands;
using Application.Authentication.Queries;
using Application.Authentication.Queries.Login;
using Application.Authentication.Queries.RefreshToken;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;

namespace Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto request)
    {
        var command = _mapper.Map<RegisterCommand>(request);
        var authResult = await _mediator.Send(command);

        return authResult.Match(
            success => Ok(_mapper.Map<AuthenticationDto>(success)),
            Problem);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto request)
    {
        var query = _mapper.Map<LoginQuery>(request);
        var authResult = await _mediator.Send(query);
        
        return authResult.Match(
            success => Ok(_mapper.Map<AuthenticationDto>(success)),
            Problem);
    }
    
    [HttpPost("refresh-token")]
    public async  Task<IActionResult> RefreshToken(RefreshTokenDto request)
    {
        var query = _mapper.Map<RefreshTokenQuery>(request);
        var authResult = await _mediator.Send(query);
        
        return authResult.Match(
            success => Ok(_mapper.Map<AuthenticationDto>(success)),
            Problem);
    }
}