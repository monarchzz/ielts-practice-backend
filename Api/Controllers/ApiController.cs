using System.Security.Claims;
using Api.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Controllers;

[ApiController]
[Authorize]
[Produces("application/json")]
public class ApiController : ControllerBase
{
    protected string? CurrentUserId =>
        HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

    protected IActionResult Problem(List<Error> errors)
    {
        if (errors is { Count: 0 })
        {
            return Problem();
        }

        HttpContext.Items[HttpContextItemKeys.Errors] = errors;

        var firstError = errors.First();

        return Problem(firstError);
    }

    private IActionResult Problem(Error error)
    {
        var statusCode = error.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode: statusCode, title: error.Description);
    }
}