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

    #region Get Blogs

    [HttpGet]
    public async Task<IActionResult> GetBlogs(
        int pageNo,
        int pageSize,
        CancellationToken cancellationToken
    )
    {
        var result = await _bL_Blog.GetBlogsAsync(pageNo, pageSize, cancellationToken);
        return Content(result);
    }

    #endregion

    #region Get Blog

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBlog(int id, CancellationToken cancellationToken)
    {
        var result = await _bL_Blog.GetBlogAsync(id, cancellationToken);
        return Content(result);
    }

    #endregion

    [HttpPost]
    public async Task<IActionResult> CreateBlog(
        [FromBody] BlogRequestDto blogDto,
        CancellationToken cancellationToken
    )
    {
        var result = await _bL_Blog.AddBlogAsync(blogDto, cancellationToken);
        return Content(result);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchBlog(
        [FromBody] BlogRequestDto blogRequest,
        int id,
        CancellationToken cancellationToken
    )
    {
        var result = await _bL_Blog.PatchBlogAsync(blogRequest, id, cancellationToken);
        return Content(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBlog(
        [FromBody] BlogRequestDto blogRequest,
        int id,
        CancellationToken cancellationToken
    )
    {
        var result = await _bL_Blog.UpdateBlogAsync(blogRequest, id, cancellationToken);
        return Content(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBlog(int id, CancellationToken cancellationToken)
    {
        var result = await _bL_Blog.DeleteBlogAsync(id, cancellationToken);
        return Content(result);
    }
}
