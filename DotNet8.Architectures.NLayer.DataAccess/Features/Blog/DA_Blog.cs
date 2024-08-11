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

    public async Task<Result<BlogListDto>> GetBlogs(int pageNo, int pageSize)
    {
        Result<BlogListDto> result;
        try
        {
            var query = _context.Tbl_Blogs.OrderByDescending(x => x.BlogId);
            var lst = await query.Skip((pageNo - 1) * pageSize).Take(pageSize).ToListAsync();

            var totalCount = await query.CountAsync();
            var pageCount = totalCount / pageSize;

            if (totalCount % pageSize > 0)
            {
                pageCount++;
            }

            var pageSettingModel = new PageSettingModel(pageNo, pageSize, pageCount, totalCount);
            result = Result<BlogListDto>.Success(new BlogListDto { DataLst = lst.Select(x => x.ToDto()), PageSetting = pageSettingModel });
        }
        catch (Exception ex)
        {
            result = Result<BlogListDto>.Failure(ex);
        }

        return result;
    }
}
