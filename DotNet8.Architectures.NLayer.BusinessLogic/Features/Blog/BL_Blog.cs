using DotNet8.Architectures.DTOs.Features.Blog;
using DotNet8.Architectures.NLayer.DataAccess.Features.Blog;
using DotNet8.Architectures.Utils;
using DotNet8.Architectures.Utils.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Architectures.NLayer.BusinessLogic.Features.Blog
{
    public class BL_Blog
    {
        private readonly DA_Blog _dA_Blog;

        public BL_Blog(DA_Blog dA_Blog)
        {
            _dA_Blog = dA_Blog;
        }

        public async Task<Result<BlogListDto>> GetBlogs(int pageNo, int pageSize)
        {
            Result<BlogListDto> result;

            if (pageNo <= 0)
            {
                result = Result<BlogListDto>.Failure(MessageResource.InvalidPageNo);
                goto result;
            }

            if (pageSize <= 0)
            {
                result = Result<BlogListDto>.Failure(MessageResource.InvalidPageSize);
                goto result;
            }

            result = await _dA_Blog.GetBlogs(pageNo, pageSize);

        result:
            return result;
        }
    }
}
