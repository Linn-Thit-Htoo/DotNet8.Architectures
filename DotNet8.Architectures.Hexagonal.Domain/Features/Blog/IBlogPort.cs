namespace DotNet8.Architectures.Hexagonal.Domain.Features.Blog;

public interface IBlogPort
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