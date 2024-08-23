using Microsoft.AspNetCore.Http;

namespace DotNet8.Architectures.Microservices.Blog.Features
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IActionResult Content(object obj)
        {
            return Content(obj.ToJson(), "application/json");
        }
    }
}
