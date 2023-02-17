using System.Diagnostics;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchApi.WebApi.Controllers;

[ApiController]
[ApiExplorerSettings(IgnoreApi = true)]
public class ErrorsController : ControllerBase
{
    [Route("error")]
    public ActionResult<dynamic> Error()
    {
        var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
        var except = context?.Error;

        var errorId = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
        Response.StatusCode = 500;

        return new
        {
            Id = errorId,
            Date = DateTime.UtcNow,
            Message = "Unexpected Error"
        };
    }
}
