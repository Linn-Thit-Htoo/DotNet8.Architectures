using DotNet8.Architectures.DTOs.Features.Blog;
using DotNet8.Architectures.Utils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Architectures.Clean.Application.Blog.GetBlogList
{
    public class GetBlogListQuery : IRequest<Result<BlogListDtoV1>>
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }

        public GetBlogListQuery(int pageNo, int pageSize)
        {
            PageNo = pageNo;
            PageSize = pageSize;
        }
    }
}
