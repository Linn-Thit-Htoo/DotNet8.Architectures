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

    #region Get Blogs Async

    public async Task<Result<BlogListDto>> GetBlogsAsync(
        int pageNo,
        int pageSize,
        CancellationToken cancellationToken
    )
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

        result = await _dA_Blog.GetBlogsAsync(pageNo, pageSize, cancellationToken);

    result:
        return result;
    }

    #endregion

    public async Task<Result<BlogDto>> GetBlogAsync(int id, CancellationToken cancellationToken)
    {
        Result<BlogDto> result;

        if (id <= 0)
        {
            result = Result<BlogDto>.Failure(MessageResource.InvalidId);
            goto result;
        }

        result = await _dA_Blog.GetBlogAsync(id, cancellationToken);

    result:
        return result;
    }

    public async Task<Result<BlogDto>> AddBlogAsync(
        BlogRequestDto blogRequest,
        CancellationToken cancellationToken
    )
    {
        Result<BlogDto> result;

        var validationResult = await _blogValidator.ValidateAsync(blogRequest);
        if (!validationResult.IsValid)
        {
            string errors = string.Join(" ", validationResult.Errors.Select(x => x.ErrorMessage));
            result = Result<BlogDto>.Failure(errors);
            goto result;
        }

        result = await _dA_Blog.AddBlogAsync(blogRequest, cancellationToken);

    result:
        return result;
    }

    public async Task<Result<BlogDto>> UpdateBlogAsync(
        BlogRequestDto blogRequest,
        int id,
        CancellationToken cancellationToken
    )
    {
        Result<BlogDto> result;

        var validationResult = await _blogValidator.ValidateAsync(blogRequest);
        if (!validationResult.IsValid)
        {
            string errors = string.Join(" ", validationResult.Errors.Select(x => x.ErrorMessage));
            result = Result<BlogDto>.Failure(errors);
            goto result;
        }

        if (id <= 0)
        {
            result = Result<BlogDto>.Failure(MessageResource.InvalidId);
            goto result;
        }

        result = await _dA_Blog.UpdateBlogAsync(blogRequest, id, cancellationToken);

    result:
        return result;
    }

    public async Task<Result<BlogDto>> PatchBlogAsync(
        BlogRequestDto requestDto,
        int id,
        CancellationToken cancellationToken
    )
    {
        Result<BlogDto> result;
        try
        {
            if (id <= 0)
            {
                result = Result<BlogDto>.Failure(MessageResource.InvalidId);
                goto result;
            }

            result = await _dA_Blog.PatchBlogAsync(requestDto, id, cancellationToken);
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
            if (id <= 0)
            {
                result = Result<BlogDto>.Failure(MessageResource.InvalidId);
                goto result;
            }

            result = await _dA_Blog.DeleteBlogAsync(id, cancellationToken);
        }
        catch (Exception ex)
        {
            result = Result<BlogDto>.Failure(ex);
        }

    result:
        return result;
    }
}
