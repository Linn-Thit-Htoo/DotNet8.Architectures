using DotNet8.Architectures.Shared;

namespace DotNet8.Architectures.Clean.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected IActionResult Content(object obj)
    {
        return Content(obj.ToJson(), "application/json");
    }
}
