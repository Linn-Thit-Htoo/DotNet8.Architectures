using DotNet8.Architectures.DbService;
using DotNet8.Architectures.DTOs.Features.Blog;
using DotNet8.Architectures.DTOs.Features.PageSetting;
using DotNet8.Architectures.Extensions;
using DotNet8.Architectures.Utils;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.Architectures.NLayer.DataAccess.Features.Blog;

public class DA_Blog
{
    private readonly AppDbContext _context;

    public DA_Blog(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<BlogListDto>> GetBlogsAsync(int pageNo, int pageSize, CancellationToken cancellationToken)
    {
        Result<BlogListDto> result;
        try
        {
            var query = _context.Tbl_Blogs.OrderByDescending(x => x.BlogId);
            var lst = await query.Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync(cancellationToken);

            var totalCount = await query.CountAsync(cancellationToken);
            var pageCount = totalCount / pageSize;

            if (totalCount % pageSize > 0)
            {
                pageCount++;
            }

            var pageSettingModel = new PageSettingModel(pageNo, pageSize, pageCount, totalCount);
            result = Result<BlogListDto>.Success(
                new BlogListDto
                {
                    DataLst = lst.Select(x => x.ToDto()),
                    PageSetting = pageSettingModel
                }
            );
        }
        catch (Exception ex)
        {
            result = Result<BlogListDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<BlogDto>> GetBlogAsync(int id, CancellationToken cancellationToken)
    {
        Result<BlogDto> result;
        try
        {
            var blog = await _context.Tbl_Blogs.FindAsync([id], cancellationToken: cancellationToken);
            if (blog is null)
            {
                result = Result<BlogDto>.NotFound("Blog Not Found.");
                goto result;
            }

            result = Result<BlogDto>.Success(blog.ToDto());
        }
        catch (Exception ex)
        {
            result = Result<BlogDto>.Failure(ex);
        }

    result:
        return result;
    }

    public async Task<Result<BlogDto>> AddBlogAsync(BlogRequestDto blogDto, CancellationToken cancellationToken)
    {
        Result<BlogDto> result;
        try
        {
            await _context.Tbl_Blogs.AddAsync(blogDto.ToEntity(), cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            result = Result<BlogDto>.SaveSuccess();
        }
        catch (Exception ex)
        {
            result = Result<BlogDto>.Failure(ex);
        }

        return result;
    }

    public async Task<Result<BlogDto>> UpdateBlogAsync(BlogRequestDto blogDto, int id, CancellationToken cancellationToken)
    {
        Result<BlogDto> result;
        try
        {
            var blog = await _context.Tbl_Blogs.FirstOrDefaultAsync(x => x.BlogId == id, cancellationToken: cancellationToken);
            if (blog is null)
            {
                result = Result<BlogDto>.NotFound();
                goto result;
            }

            blog.BlogTitle = blogDto.BlogTitle;
            blog.BlogAuthor = blogDto.BlogAuthor;
            blog.BlogContent = blogDto.BlogContent;

            _context.Tbl_Blogs.Update(blog);
            await _context.SaveChangesAsync(cancellationToken);

            result = Result<BlogDto>.UpdateSuccess();
        }
        catch (Exception ex)
        {
            result = Result<BlogDto>.Failure(ex);
        }

    result:
        return result;
    }

    public async Task<Result<BlogDto>> DeleteBlogAsync(int id, CancellationToken cancellationToken)
    {
        Result<BlogDto> result;
        try
        {
            var blog = await _context.Tbl_Blogs.FirstOrDefaultAsync(x => x.BlogId == id, cancellationToken: cancellationToken);
            if (blog is null)
            {
                result = Result<BlogDto>.NotFound();
                goto result;
            }

            _context.Tbl_Blogs.Remove(blog);
            await _context.SaveChangesAsync(cancellationToken);

            result = Result<BlogDto>.DeleteSuccess();
        }
        catch (Exception ex)
        {
            result = Result<BlogDto>.Failure(ex);
        }

    result:
        return result;
    }
}
