using DotNet8.Architectures.DTOs.Features.Blog;
using DotNet8.Architectures.NLayer.BusinessLogic.Features.Blog;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.Architectures.NLayer.Presentation.Controllers.Blog;

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
        var result = await _bL_Blog.GetBlogsAsync(pageNo, pageSize);
        return Content(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBlog(int id)
    {
        var result = await _bL_Blog.GetBlogAsync(id);
        return Content(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBlog([FromBody] BlogRequestDto blogDto)
    {
        var result = await _bL_Blog.AddBlogAsync(blogDto);
        return Content(result);
    }
}
