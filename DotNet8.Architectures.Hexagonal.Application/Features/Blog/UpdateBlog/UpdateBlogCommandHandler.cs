using DotNet8.Architectures.DTOs.Features.Blog;
using DotNet8.Architectures.Hexagonal.Domain.Features.Blog;
using DotNet8.Architectures.Shared;
using DotNet8.Architectures.Utils;
using MediatR;

namespace DotNet8.Architectures.Hexagonal.Application.Features.Blog.UpdateBlog;

public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, Result<BlogDto>>
{
    private readonly IBlogPort _blogPort;

    public UpdateBlogCommandHandler(IBlogPort blogPort)
    {
        _blogPort = blogPort;
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

        result = await _blogPort.UpdateBlogAsync(
            request.RequestDto,
            request.BlogId,
            cancellationToken
        );

    result:
        return result;
    }
}
