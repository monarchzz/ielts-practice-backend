using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("[controller]")]
[Authorize(Roles = $"{nameof(Role.User)},{nameof(Role.Admin)}, {nameof(Role.Manager)}")]
public class SampleController : ApiController
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { CurrentUserId });
    }
}