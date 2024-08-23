namespace DotNet8.Architectures.Hexagonal.Application.Features.Blog.CreateBlog;

public class CreateBlogCommand : IRequest<Result<BlogDto>>
{
    public BlogRequestDto requestDto;

    public CreateBlogCommand(BlogRequestDto requestDto)
    {
        this.requestDto = requestDto;
    }
}
