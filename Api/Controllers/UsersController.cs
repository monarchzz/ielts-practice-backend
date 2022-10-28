using Api.Dtos.Users;
using Application.Users.Queries.Profile;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("[controller]")]
public class UsersController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UsersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet("profile")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProfile()
    {
        if (CurrentUserId == null) return Unauthorized();
        var userResult = await _mediator.Send(new ProfileQuery
        {
            Id = Guid.Parse(CurrentUserId)
        });

        return userResult.Match(success => Ok(_mapper.Map<UserDto>(success)), Problem);
    }
}