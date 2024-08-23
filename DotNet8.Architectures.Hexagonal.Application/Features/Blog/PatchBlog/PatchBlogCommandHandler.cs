namespace DotNet8.Architectures.Hexagonal.Application.Features.Blog.PatchBlog;

public class PatchBlogCommandHandler : IRequestHandler<PatchBlogCommand, Result<BlogDto>>
{
    private readonly IBlogPort _blogPort;

    public PatchBlogCommandHandler(IBlogPort blogPort)
    {
        _blogPort = blogPort;
    }

    public async Task<Result<BlogDto>> Handle(
        PatchBlogCommand request,
        CancellationToken cancellationToken
    )
    {
        Result<BlogDto> result;

        if (request.BlogId <= 0)
        {
            result = Result<BlogDto>.Failure(MessageResource.InvalidId);
            goto result;
        }

        result = await _blogPort.PatchBlogAsync(
            request.BlogRequestDto,
            request.BlogId,
            cancellationToken
        );

    result:
        return result;
    }
}
