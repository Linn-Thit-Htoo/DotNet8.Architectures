using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.Architectures.Microservices.Blog.Features.Blog
{
    [Route("api/blogs")]
    [ApiController]
    public class BlogController : BaseController
    {
        private readonly DA_Blog _dA_Blog;

        public BlogController(DA_Blog dA_Blog)
        {
            _dA_Blog = dA_Blog;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogs(int pageNo, int pageSize, CancellationToken cancellationToken)
        {
            var result = await _dA_Blog.GetBlogsAsync(pageNo, pageSize, cancellationToken);
            return Content(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id, CancellationToken cancellationToken)
        {
            var result = await _dA_Blog.GetBlogByIdAsync(id, cancellationToken);
            return Content(result);
        }
    }
}
