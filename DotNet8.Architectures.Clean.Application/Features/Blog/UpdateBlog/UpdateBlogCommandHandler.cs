using DotNet8.Architectures.Clean.Domain.Features.Blog;
using DotNet8.Architectures.Shared;

namespace DotNet8.Architectures.Clean.Application.Features.Blog.UpdateBlog;

public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, Result<BlogDto>>
{
    private readonly IBlogRepository _blogRepository;

    public UpdateBlogCommandHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<Result<BlogDto>> Handle(
        UpdateBlogCommand request,
        CancellationToken cancellationToken
    )
    {
        Result<BlogDto> result;

        if (request.RequestDto.BlogTitle.IsNullOrEmpty())
        {
            result = Result<BlogDto>.Failure("Blog Title cannot be empty.");
            goto result;
        }

        if (request.RequestDto.BlogAuthor.IsNullOrEmpty())
        {
            result = Result<BlogDto>.Failure("Blog Author cannot be empty.");
            goto result;
        }

        if (request.RequestDto.BlogContent.IsNullOrEmpty())
        {
            result = Result<BlogDto>.Failure("Blog Content");
            goto result;
        }

        result = await _blogRepository.UpdateBlogAsync(
            request.RequestDto,
            request.BlogId,
            cancellationToken
        );

    result:
        return result;
    }
}
