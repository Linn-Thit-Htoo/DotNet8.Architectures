namespace DotNet8.Architectures.Hexagonal.Application.Features.Blog.UpdateBlog;

public class UpdateBlogCommand : IRequest<Result<BlogDto>>
{
    public BlogRequestDto RequestDto { get; set; }
    public int BlogId { get; set; }

    public UpdateBlogCommand(BlogRequestDto requestDto, int blogId)
    {
        RequestDto = requestDto;
        BlogId = blogId;
    }
}
