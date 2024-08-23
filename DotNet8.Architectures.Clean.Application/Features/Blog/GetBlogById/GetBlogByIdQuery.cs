namespace DotNet8.Architectures.Clean.Application.Features.Blog.GetBlogById;

public class GetBlogByIdQuery : IRequest<Result<BlogDto>>
{
    public int BlogId { get; set; }

    public GetBlogByIdQuery(int blogId)
    {
        BlogId = blogId;
    }
}
