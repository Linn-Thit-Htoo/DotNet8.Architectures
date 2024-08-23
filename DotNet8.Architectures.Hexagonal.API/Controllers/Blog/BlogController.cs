﻿using DotNet8.Architectures.DTOs.Features.Blog;
using DotNet8.Architectures.Hexagonal.Application.Features.Blog.CreateBlog;
using DotNet8.Architectures.Hexagonal.Application.Features.Blog.DeleteBlog;
using DotNet8.Architectures.Hexagonal.Application.Features.Blog.GetBlogById;
using DotNet8.Architectures.Hexagonal.Application.Features.Blog.GetBlogList;
using DotNet8.Architectures.Hexagonal.Application.Features.Blog.PatchBlog;
using DotNet8.Architectures.Hexagonal.Application.Features.Blog.UpdateBlog;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.Architectures.Hexagonal.API.Controllers.Blog
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : BaseController
    {
        private readonly IMediator _mediator;

        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogs(
            int pageNo,
            int pageSize,
            CancellationToken cancellationToken
        )
        {
            var query = new GetBlogListQuery(pageNo, pageSize);
            var result = await _mediator.Send(query, cancellationToken);

            return Content(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(int id, CancellationToken cancellationToken)
        {
            var query = new GetBlogByIdQuery(id);
            var result = await _mediator.Send(query, cancellationToken);

            return Content(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(
            [FromBody] BlogRequestDto requestDto,
            CancellationToken cancellationToken
        )
        {
            var command = new CreateBlogCommand(requestDto);
            var result = await _mediator.Send(command, cancellationToken);

            return Content(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBlog(
            [FromBody] BlogRequestDto requestDto,
            int id,
            CancellationToken cancellationToken
        )
        {
            var command = new UpdateBlogCommand(requestDto, id);
            var result = await _mediator.Send(command, cancellationToken);

            return Content(result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchBlog([FromBody] BlogRequestDto requestDto, int id, CancellationToken cancellationToken)
        {
            var command = new PatchBlogCommand(requestDto, id);
            var result = await _mediator.Send(command, cancellationToken);

            return Content(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id, CancellationToken cancellationToken)
        {
            var command = new DeleteBlogCommand(id);
            var result = await _mediator.Send(command, cancellationToken);

            return Content(result);
        }
    }
}
