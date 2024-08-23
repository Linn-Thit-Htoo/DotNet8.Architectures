namespace DotNet8.Architectures.Hexagonal.Application.Features.Blog.GetBlogById;

public class GetBlogByIdQuery : IRequest<Result<BlogDto>>
{
    public int BlogId { get; set; }

    public GetBlogByIdQuery(int blogId)
    {
        BlogId = blogId;
    }
}
