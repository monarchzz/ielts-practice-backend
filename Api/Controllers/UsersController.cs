using Api.Dtos.Users;
using Application.Users.Commands.CreateUser;
using Application.Users.Commands.UpdateUser;
using Application.Users.Queries.GetUser;
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

    [HttpGet("{id:guid}", Name = nameof(GetUserById))]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var userResult = await _mediator.Send(new GetUserQuery()
        {
            Id = id
        });

        return userResult.Match(success => Ok(_mapper.Map<UserDto>(success)), Problem);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateUser(CreateUserDto dto)
    {
        var userResult = await _mediator.Send(_mapper.Map<CreateUserCommand>(dto));

        return userResult.Match(success => CreatedAtRoute(nameof(GetUserById), new { success.Id }, null), Problem);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateUser(Guid id, UpdateUserDto dto)
    {
        var updateUserCommand = _mapper.Map<UpdateUserCommand>(dto);
        updateUserCommand.Id = id;

        var userResult = await _mediator.Send(updateUserCommand);

        return userResult.Match(_ => NoContent(), Problem);
    }
}