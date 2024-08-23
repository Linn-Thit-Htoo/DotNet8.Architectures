using DotNet8.Architectures.Clean.Domain.Features.Blog;
using DotNet8.Architectures.DTOs.Features.Blog;
using DotNet8.Architectures.Utils;
using DotNet8.Architectures.Utils.Resources;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Architectures.Clean.Application.Features.Blog.PatchBlog
{
    public class PatchBlogCommandHandler : IRequestHandler<PatchBlogCommand, Result<BlogDto>>
    {
        private readonly IBlogRepository _blogRepository;

        public PatchBlogCommandHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<Result<BlogDto>> Handle(PatchBlogCommand request, CancellationToken cancellationToken)
        {
            Result<BlogDto> result;

            if (request.BlogId <= 0)
            {
                result = Result<BlogDto>.Failure(MessageResource.InvalidId);
                goto result;
            }

            result = await _blogRepository.PatchBlogAsync(request.BlogRequestDto, request.BlogId, cancellationToken);

        result:
            return result;
        }
    }
}
