namespace DotNet8.Architectures.ModularMonolithic.Modules.Application.Features.Blog.CreateBlog;

public class CreateBlogCommand : IRequest<Result<BlogDto>>
{
    public BlogRequestDto requestDto;

    public CreateBlogCommand(BlogRequestDto requestDto)
    {
        this.requestDto = requestDto;
    }
}
