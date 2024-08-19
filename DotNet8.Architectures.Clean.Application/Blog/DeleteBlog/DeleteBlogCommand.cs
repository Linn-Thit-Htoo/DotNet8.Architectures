using DotNet8.Architectures.DTOs.Features.Blog;
using DotNet8.Architectures.Utils;
using MediatR;

namespace DotNet8.Architectures.Clean.Application.Blog.DeleteBlog;

public class DeleteBlogCommand : IRequest<Result<BlogDto>>
{
    public int BlogId { get; set; }

    public DeleteBlogCommand(int blogId)
    {
        BlogId = blogId;
    }
}
