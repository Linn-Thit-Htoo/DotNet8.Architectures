using DotNet8.Architectures.DTOs.Features.Blog;
using DotNet8.Architectures.NLayer.DataAccess.Features.Blog;
using DotNet8.Architectures.Shared;
using DotNet8.Architectures.Utils;
using DotNet8.Architectures.Utils.Resources;

namespace DotNet8.Architectures.NLayer.BusinessLogic.Features.Blog;

public class BL_Blog
{
    private readonly DA_Blog _dA_Blog;
    private readonly BlogValidator _blogValidator;

    public BL_Blog(DA_Blog dA_Blog, BlogValidator blogValidator)
    {
        _dA_Blog = dA_Blog;
        _blogValidator = blogValidator;
    }

    public async Task<Result<BlogListDto>> GetBlogsAsync(int pageNo, int pageSize)
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

        result = await _dA_Blog.GetBlogsAsync(pageNo, pageSize);

    result:
        return result;
    }

    public async Task<Result<BlogDto>> GetBlogAsync(int id)
    {
        Result<BlogDto> result;

        if (id <= 0)
        {
            result = Result<BlogDto>.Failure(MessageResource.InvalidId);
            goto result;
        }

        result = await _dA_Blog.GetBlogAsync(id);

    result:
        return result;
    }

    public async Task<Result<BlogDto>> AddBlogAsync(BlogRequestDto blogDto)
    {
        Result<BlogDto> result;

        var validationResult = await _blogValidator.ValidateAsync(blogDto);
        if (!validationResult.IsValid)
        {
            string errors = string.Join(" ", validationResult.Errors.Select(x => x.ErrorMessage));
            result = Result<BlogDto>.Failure(errors);
            goto result;
        }

        result = await _dA_Blog.AddBlogAsync(blogDto);

    result:
        return result;
    }
}
