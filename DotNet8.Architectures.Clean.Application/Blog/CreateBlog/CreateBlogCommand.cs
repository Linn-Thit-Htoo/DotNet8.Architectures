using DotNet8.Architectures.DTOs.Features.Blog;
using DotNet8.Architectures.Utils;
using MediatR;

namespace DotNet8.Architectures.Clean.Application.Blog.CreateBlog;

public class CreateBlogCommand : IRequest<Result<BlogDto>>
{
    public BlogRequestDto requestDto;

    public CreateBlogCommand(BlogRequestDto requestDto)
    {
        this.requestDto = requestDto;
    }
}
