namespace DotNet8.Architectures.Hexagonal.Application.Features.Blog.PatchBlog;

public class PatchBlogCommand : IRequest<Result<BlogDto>>
{
    public BlogRequestDto BlogRequestDto { get; set; }

    public int BlogId { get; set; }

    public PatchBlogCommand(BlogRequestDto blogRequestDto, int blogId)
    {
        BlogRequestDto = blogRequestDto;
        BlogId = blogId;
    }
}
