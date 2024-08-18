using DotNet8.Architectures.DTOs.Features.Blog;
using DotNet8.Architectures.Utils;
using MediatR;

namespace DotNet8.Architectures.Clean.Application.Blog.GetBlogById
{
    public class GetBlogByIdQuery : IRequest<Result<BlogDto>>
    {
        public int BlogId { get; set; }

        public GetBlogByIdQuery(int blogId)
        {
            BlogId = blogId;
        }
    }
}
