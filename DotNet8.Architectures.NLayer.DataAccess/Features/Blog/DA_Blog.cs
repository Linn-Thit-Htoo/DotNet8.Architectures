using DotNet8.Architectures.DbService;
using DotNet8.Architectures.DTOs.Features.Blog;
using DotNet8.Architectures.DTOs.Features.PageSetting;
using DotNet8.Architectures.Extensions;
using DotNet8.Architectures.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Architectures.NLayer.DataAccess.Features.Blog
{
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
                var query = _context.Tbl_Blogs.OrderByDescending(x => x.BlogId)
                    .Skip((pageNo - 1) * pageSize).Take(pageSize);
                var lst = await query.ToListAsync();

                var totalCount = await query.CountAsync();
                var pageCount = totalCount / pageSize;

                if (totalCount % pageSize > 0)
                {
                    pageCount++;
                }

                var pageSettingModel = new PageSettingModel(pageNo, pageSize, pageCount, totalCount);
                result = Result<BlogListDto>.Success(new BlogListDto { DataLst = lst.Select(x => x.ToDto()), PageSetting = pageSettingModel});
            }
            catch (Exception ex)
            {
                result = Result<BlogListDto>.Failure(ex);
            }

            return result;
        }
    }
}
