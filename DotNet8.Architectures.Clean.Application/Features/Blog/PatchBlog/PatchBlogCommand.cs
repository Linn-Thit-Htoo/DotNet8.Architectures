using DotNet8.Architectures.DTOs.Features.Blog;
using DotNet8.Architectures.Utils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Architectures.Clean.Application.Features.Blog.PatchBlog
{
    public class PatchBlogCommand : IRequest<Result<BlogDto>>
    {
        public BlogRequestDto BlogRequestDto { get; set; }

        public int BlogId { get; set; }

        public PatchBlogCommand(BlogRequestDto blogRequestDto, int blogId)
        {
            BlogRequestDto = blogRequestDto;
            BlogId = blogId;
        }
    }
}
