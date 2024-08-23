using DotNet8.Architectures.Clean.Domain.Features.Blog;
using DotNet8.Architectures.DTOs.Features.Blog;
using DotNet8.Architectures.Utils;
using DotNet8.Architectures.Utils.Resources;
using MediatR;

namespace DotNet8.Architectures.Clean.Application.Blog.GetBlogList;

public class GetBlogListQueryHandler : IRequestHandler<GetBlogListQuery, Result<BlogListDtoV1>>
{
    private readonly IBlogRepository _blogRepository;

    public GetBlogListQueryHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<Result<BlogListDtoV1>> Handle(
        GetBlogListQuery request,
        CancellationToken cancellationToken
    )
    {
        Result<BlogListDtoV1> result;

        if (request.PageNo <= 0)
        {
            result = Result<BlogListDtoV1>.Failure(MessageResource.InvalidPageNo);
            goto result;
        }

        if (request.PageSize <= 0)
        {
            result = Result<BlogListDtoV1>.Failure(MessageResource.InvalidPageSize);
            goto result;
        }

        result = await _blogRepository.GetBlogsAsync(
            request.PageNo,
            request.PageSize,
            cancellationToken
        );

    result:
        return result;
    }
}
