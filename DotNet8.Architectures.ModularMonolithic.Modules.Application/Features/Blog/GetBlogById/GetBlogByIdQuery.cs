using DotNet8.Architectures.DTOs.Features.Blog;
using DotNet8.Architectures.Utils;
using MediatR;

namespace DotNet8.Architectures.ModularMonolithic.Modules.Application.Features.Blog.GetBlogById;

public class GetBlogByIdQuery : IRequest<Result<BlogDto>>
{
    public int BlogId { get; set; }

    public GetBlogByIdQuery(int blogId)
    {
        BlogId = blogId;
    }
}
