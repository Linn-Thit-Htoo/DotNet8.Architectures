﻿namespace DotNet8.Architectures.ModularMonolithic.Modules.Application.Features.Blog.PatchBlog;

public class PatchBlogCommandHandler : IRequestHandler<PatchBlogCommand, Result<BlogDto>>
{
    private readonly IBlogRepository _blogRepository;

    public PatchBlogCommandHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
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

        result = await _blogRepository.PatchBlogAsync(
            request.BlogRequestDto,
            request.BlogId,
            cancellationToken
        );

    result:
        return result;
    }
}
