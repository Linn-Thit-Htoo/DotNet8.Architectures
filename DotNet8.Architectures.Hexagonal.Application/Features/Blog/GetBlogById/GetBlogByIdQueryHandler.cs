using DotNet8.Architectures.Utils.Resources;

namespace DotNet8.Architectures.Hexagonal.Application.Features.Blog.GetBlogById;

public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, Result<BlogDto>>
{
    private readonly IBlogPort _blogPort;

    public GetBlogByIdQueryHandler(IBlogPort blogPort)
    {
        _blogPort = blogPort;
    }

    public async Task<Result<BlogDto>> Handle(
        GetBlogByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        Result<BlogDto> result;

        if (request.BlogId <= 0)
        {
            result = Result<BlogDto>.Failure(MessageResource.InvalidId);
            goto result;
        }

        result = await _blogPort.GetBlogByIdAsync(request.BlogId, cancellationToken);

    result:
        return result;
    }
}
