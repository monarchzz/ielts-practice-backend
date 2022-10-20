using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("[controller]")]
public class SampleController : ApiController
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { CurrentUserId });
    }
}