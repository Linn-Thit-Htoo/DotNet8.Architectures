using DotNet8.Architectures.Clean.Domain.Blog;
using DotNet8.Architectures.DTOs.Features.Blog;
using DotNet8.Architectures.Utils;
using DotNet8.Architectures.Utils.Resources;
using MediatR;

namespace DotNet8.Architectures.Clean.Application.Blog.GetBlogById;

public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, Result<BlogDto>>
{
    private readonly IBlogRepository _blogRepository;

    public GetBlogByIdQueryHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<Result<BlogDto>> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
    {
        Result<BlogDto> result;

        if (request.BlogId <= 0)
        {
            result = Result<BlogDto>.Failure(MessageResource.InvalidId);
            goto result;
        }

        result = await _blogRepository.GetBlogByIdAsync(request.BlogId, cancellationToken);

    result:
        return result;
    }
}
