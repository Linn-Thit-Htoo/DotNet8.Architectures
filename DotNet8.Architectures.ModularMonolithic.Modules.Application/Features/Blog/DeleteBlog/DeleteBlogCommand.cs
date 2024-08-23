namespace DotNet8.Architectures.ModularMonolithic.Modules.Application.Features.Blog.DeleteBlog;

public class DeleteBlogCommand : IRequest<Result<BlogDto>>
{
    public int BlogId { get; set; }

    public DeleteBlogCommand(int blogId)
    {
        BlogId = blogId;
    }
}
