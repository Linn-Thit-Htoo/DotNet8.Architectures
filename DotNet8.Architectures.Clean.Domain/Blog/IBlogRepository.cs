using DotNet8.Architectures.DTOs.Features.Blog;
using DotNet8.Architectures.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Architectures.Clean.Domain.Blog
{
    public interface IBlogRepository
    {
        Task<Result<BlogListDtoV1>> GetBlogsAsync(int pageNo, int pageSize, CancellationToken cancellationToken);
        Task<Result<BlogDto>> GetBlogByIdAsync(int id, CancellationToken cancellationToken);
        Task<Result<BlogDto>> AddBlogAsync(BlogRequestDto blogRequest, CancellationToken cancellationToken);
    }
}
