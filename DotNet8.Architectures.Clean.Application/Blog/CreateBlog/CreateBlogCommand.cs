using DotNet8.Architectures.DTOs.Features.Blog;
using DotNet8.Architectures.Utils;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Architectures.Clean.Application.Blog.CreateBlog
{
    public class CreateBlogCommand : IRequest<Result<BlogDto>>
    {
        public BlogRequestDto requestDto;

        public CreateBlogCommand(BlogRequestDto requestDto)
        {
            this.requestDto = requestDto;
        }
    }
}
