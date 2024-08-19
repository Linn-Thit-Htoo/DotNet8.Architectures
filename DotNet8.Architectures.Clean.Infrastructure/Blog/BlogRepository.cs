using DotNet8.Architectures.Clean.Domain.Blog;
using DotNet8.Architectures.DTOs.Features.Blog;
using DotNet8.Architectures.DTOs.Features.PageSetting;
using DotNet8.Architectures.Shared;
using DotNet8.Architectures.Utils;
using MethodTimer;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.Architectures.Clean.Infrastructure.Blog;

public class BlogRepository : IBlogRepository
{
    private readonly BlogDbContext _context;

    public BlogRepository(BlogDbContext context)
    {
        _context = context;
    }

    public async Task<Result<BlogListDtoV1>> GetBlogsAsync(
        int pageNo,
        int pageSize,
        CancellationToken cancellationToken
    )
    {
        Result<BlogListDtoV1> result;
        try
        {
            var query = _context.Tbl_Blogs.OrderByDescending(x => x.BlogId);
            var lst = await query
                .Paginate(pageNo, pageSize)
                .ToListAsync(cancellationToken: cancellationToken);
            var totalCount = await query.CountAsync(cancellationToken: cancellationToken);
            var pageCount = totalCount / pageSize;
            if (totalCount % pageSize > 0)
            {
                pageCount++;
            }

            var pageSettingModel = new PageSettingModel(pageNo, pageSize, pageCount, totalCount);
            var model = new BlogListDtoV1()
            {
                DataLst = lst.Select(x => new BlogDto()
                {
                    BlogId = x.BlogId,
                    BlogTitle = x.BlogTitle,
                    BlogAuthor = x.BlogAuthor,
                    BlogContent = x.BlogContent
                })
                    .AsQueryable(),
                PageSetting = pageSettingModel
            };

            result = Result<BlogListDtoV1>.Success(model);
        }
        catch (Exception ex)
        {
            result = Result<BlogListDtoV1>.Failure(ex);
        }

        return result;
    }

    [Time]
    public async Task<Result<BlogDto>> GetBlogByIdAsync(int id, CancellationToken cancellationToken)
    {
        Result<BlogDto> result;
        try
        {
            var blog = await _context.Tbl_Blogs.FindAsync(
                [id, cancellationToken],
                cancellationToken: cancellationToken
            );
            if (blog is null)
            {
                result = Result<BlogDto>.NotFound();
                goto result;
            }

            result = Result<BlogDto>.Success(
                new BlogDto()
                {
                    BlogId = blog.BlogId,
                    BlogTitle = blog.BlogTitle,
                    BlogAuthor = blog.BlogAuthor,
                    BlogContent = blog.BlogContent
                }
            );
        }
        catch (Exception ex)
        {
            result = Result<BlogDto>.Failure(ex);
        }

    result:
        return result;
    }

    public async Task<Result<BlogDto>> AddBlogAsync(
        BlogRequestDto blogRequest,
        CancellationToken cancellationToken
    )
    {
        Result<BlogDto> result;

        try
        {
            var blog = new Tbl_Blog()
            {
                BlogTitle = blogRequest.BlogTitle,
                BlogAuthor = blogRequest.BlogAuthor,
                BlogContent = blogRequest.BlogContent
            };
            await _context.Tbl_Blogs.AddAsync(blog, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            result = Result<BlogDto>.SaveSuccess();
        }
        catch (Exception ex)
        {
            result = Result<BlogDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<BlogDto>> UpdateBlogAsync(BlogRequestDto requestDto, int id, CancellationToken cancellationToken)
    {
        Result<BlogDto> result;
        try
        {
            var blog = await _context.Tbl_Blogs.FindAsync([id, cancellationToken], cancellationToken: cancellationToken);
            if (blog is null)
            {
                result = Result<BlogDto>.NotFound();
                goto result;
            }

            blog.BlogTitle = requestDto.BlogTitle;
            blog.BlogAuthor = requestDto.BlogAuthor;
            blog.BlogContent = requestDto.BlogContent;

            _context.Tbl_Blogs.Update(blog);
            await _context.SaveChangesAsync();

            result = Result<BlogDto>.UpdateSuccess();
        }
        catch (Exception ex)
        {
            result = Result<BlogDto>.Failure(ex);
        }

    result:
        return result;
    }
}
