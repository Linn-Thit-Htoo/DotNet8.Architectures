using DotNet8.Architectures.DTOs.Features.Blog;
using DotNet8.Architectures.Utils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Architectures.Clean.Application.Blog.UpdateBlog
{
    public class UpdateBlogCommand : IRequest<Result<BlogDto>>
    {
        public BlogRequestDto RequestDto { get; set; }
        public int BlogId { get; set; }

        public UpdateBlogCommand(BlogRequestDto requestDto, int blogId)
        {
            RequestDto = requestDto;
            BlogId = blogId;
        }
    }
}
