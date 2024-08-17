using DotNet8.Architectures.Clean.Application.Blog.GetBlogList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.Architectures.Clean.Presentation.Controllers.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : BaseController
    {
        private readonly IMediator _mediator;

        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogs(int pageNo, int pageSize, CancellationToken cancellationToken)
        {
            var query = new GetBlogListQuery(pageNo, pageSize);
            var result = await _mediator.Send(query, cancellationToken);

            return Content(result);
        }
    }
}
