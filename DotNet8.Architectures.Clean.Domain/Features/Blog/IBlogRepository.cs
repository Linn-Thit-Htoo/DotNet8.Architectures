using DotNet8.Architectures.DTOs.Features.Blog;
using DotNet8.Architectures.Utils;

namespace DotNet8.Architectures.Clean.Domain.Features.Blog;

public interface IBlogRepository
{
    Task<Result<BlogListDtoV1>> GetBlogsAsync(
        int pageNo,
        int pageSize,
        CancellationToken cancellationToken
    );
    Task<Result<BlogDto>> GetBlogByIdAsync(int id, CancellationToken cancellationToken);
    Task<Result<BlogDto>> AddBlogAsync(
        BlogRequestDto blogRequest,
        CancellationToken cancellationToken
    );
    Task<Result<BlogDto>> UpdateBlogAsync(
        BlogRequestDto requestDto,
        int id,
        CancellationToken cancellationToken
    );
    Task<Result<BlogDto>> PatchBlogAsync(
        BlogRequestDto requestDto,
        int id,
        CancellationToken cancellationToken
    );
    Task<Result<BlogDto>> DeleteBlogAsync(int id, CancellationToken cancellationToken);
}
