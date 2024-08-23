namespace DotNet8.Architectures.Hexagonal.Application.Features.Blog.DeleteBlog;

public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, Result<BlogDto>>
{
    private readonly IBlogPort _blogPort;

    public DeleteBlogCommandHandler(IBlogPort blogPort)
    {
        _blogPort = blogPort;
    }

    public async Task<Result<BlogDto>> Handle(
        DeleteBlogCommand request,
        CancellationToken cancellationToken
    )
    {
        Result<BlogDto> result;

        if (request.BlogId <= 0)
        {
            result = Result<BlogDto>.Failure(MessageResource.InvalidId);
            goto result;
        }

        result = await _blogPort.DeleteBlogAsync(request.BlogId, cancellationToken);

    result:
        return result;
    }
}
