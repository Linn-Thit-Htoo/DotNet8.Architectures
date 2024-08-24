namespace DotNet8.Architectures.Microservices.Blog.Features.Blog;

[Route("api/blogs")]
[ApiController]
public class BlogController : BaseController
{
    private readonly DA_Blog _dA_Blog;

    public BlogController(DA_Blog dA_Blog)
    {
        _dA_Blog = dA_Blog;
    }

    #region Get Blogs

    [HttpGet] // https://localhost:7080/api/gateway/blogs?pageNo=1&pageSize=2
    public async Task<IActionResult> GetBlogs(
        int pageNo,
        int pageSize,
        CancellationToken cancellationToken
    )
    {
        var result = await _dA_Blog.GetBlogsAsync(pageNo, pageSize, cancellationToken);
        return Content(result);
    }

    #endregion

    #region Get Blog By Id

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBlogById(int id, CancellationToken cancellationToken)
    {
        var result = await _dA_Blog.GetBlogByIdAsync(id, cancellationToken);
        return Content(result);
    }

    #endregion

    #region Create Blog

    [HttpPost]
    public async Task<IActionResult> CreateBlog(
        [FromBody] BlogRequestDto blogRequest,
        CancellationToken cancellationToken
    )
    {
        var result = await _dA_Blog.AddBlogAsync(blogRequest, cancellationToken);
        return Content(result);
    }

    #endregion

    #region Update Blog

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBlog(
        [FromBody] BlogRequestDto blogRequest,
        int id,
        CancellationToken cancellationToken
    )
    {
        var result = await _dA_Blog.UpdateBlogAsync(blogRequest, id, cancellationToken);
        return Content(result);
    }

    #endregion

    #region Patch Blog

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchBlog(
        [FromBody] BlogRequestDto blogRequest,
        int id,
        CancellationToken cancellationToken
    )
    {
        var result = await _dA_Blog.PatchBlogAsync(blogRequest, id, cancellationToken);
        return Content(result);
    }

    #endregion

    #region Delete Blog

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBlog(int id, CancellationToken cancellationToken)
    {
        var result = await _dA_Blog.DeleteBlogAsync(id, cancellationToken);
        return Content(result);
    }

    #endregion
}
