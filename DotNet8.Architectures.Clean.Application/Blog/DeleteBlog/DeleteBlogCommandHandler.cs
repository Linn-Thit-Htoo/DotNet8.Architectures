﻿using DotNet8.Architectures.Clean.Domain.Blog;
using DotNet8.Architectures.DTOs.Features.Blog;
using DotNet8.Architectures.Utils;
using DotNet8.Architectures.Utils.Resources;
using MediatR;

namespace DotNet8.Architectures.Clean.Application.Blog.DeleteBlog
{
    public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, Result<BlogDto>>
    {
        private readonly IBlogRepository _blogRepository;

        public DeleteBlogCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<Result<BlogDto>> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
        {
            Result<BlogDto> result;

            if (request.BlogId <= 0)
            {
                result = Result<BlogDto>.Failure(MessageResource.InvalidId);
                goto result;
            }

            result = await _blogRepository.DeleteBlogAsync(request.BlogId, cancellationToken);

        result:
            return result;
        }
    }
}
