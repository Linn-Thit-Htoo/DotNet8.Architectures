using DotNet8.Architectures.NLayer.BusinessLogic.Features.Blog;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.Architectures.NLayer.Presentation.Controllers.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : BaseController
    {
        private readonly BL_Blog _bL_Blog;

        public BlogController(BL_Blog bL_Blog)
        {
            _bL_Blog = bL_Blog;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogs(int pageNo, int pageSize)
        {
            var result = await _bL_Blog.GetBlogs(pageNo, pageSize);
            return Content(result);
        }
    }
}
