namespace DotNet8.Architectures.Clean.Infrastructure.Features.Blog;

public class BlogRepository : IBlogRepository
{
    private readonly BlogDbContext _context;

    public BlogRepository(BlogDbContext context)
    {
        _context = context;
    }

    #region Get Blogs Async

    public async Task<Result<BlogListDtoV1>> GetBlogsAsync(
        int pageNo,
        int pageSize,
        CancellationToken cancellationToken
    )
    {
        Result<BlogListDtoV1> result;
        try
        {
            var query = _context.Tbl_Blogs.OrderByDescending(x => x.BlogId);
            var lst = await query
                .Paginate(pageNo, pageSize)
                .ToListAsync(cancellationToken: cancellationToken);
            var totalCount = await query.CountAsync(cancellationToken: cancellationToken);
            var pageCount = totalCount / pageSize;
            if (totalCount % pageSize > 0)
            {
                pageCount++;
            }

            var pageSettingModel = new PageSettingModel(pageNo, pageSize, pageCount, totalCount);
            var model = new BlogListDtoV1()
            {
                DataLst = lst.Select(x => new BlogDto()
                {
                    BlogId = x.BlogId,
                    BlogTitle = x.BlogTitle,
                    BlogAuthor = x.BlogAuthor,
                    BlogContent = x.BlogContent
                })
                    .AsQueryable(),
                PageSetting = pageSettingModel
            };

            result = Result<BlogListDtoV1>.Success(model);
        }
        catch (Exception ex)
        {
            result = Result<BlogListDtoV1>.Failure(ex);
        }

        return result;
    }

    #endregion

    #region Get Blog By Id Async

    public async Task<Result<BlogDto>> GetBlogByIdAsync(int id, CancellationToken cancellationToken)
    {
        Result<BlogDto> result;
        try
        {
            var blog = await _context.Tbl_Blogs.FindAsync(
                [id, cancellationToken],
                cancellationToken: cancellationToken
            );
            if (blog is null)
            {
                result = Result<BlogDto>.NotFound();
                goto result;
            }

            result = Result<BlogDto>.Success(
                new BlogDto()
                {
                    BlogId = blog.BlogId,
                    BlogTitle = blog.BlogTitle,
                    BlogAuthor = blog.BlogAuthor,
                    BlogContent = blog.BlogContent
                }
            );
        }
        catch (Exception ex)
        {
            result = Result<BlogDto>.Failure(ex);
        }

    result:
        return result;
    }

    #endregion

    #region Add Blog Async

    public async Task<Result<BlogDto>> AddBlogAsync(
        BlogRequestDto blogRequest,
        CancellationToken cancellationToken
    )
    {
        Result<BlogDto> result;

        try
        {
            var blog = new Tbl_Blog()
            {
                BlogTitle = blogRequest.BlogTitle,
                BlogAuthor = blogRequest.BlogAuthor,
                BlogContent = blogRequest.BlogContent
            };
            await _context.Tbl_Blogs.AddAsync(blog, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            result = Result<BlogDto>.SaveSuccess();
        }
        catch (Exception ex)
        {
            result = Result<BlogDto>.Failure(ex);
        }

        return result;
    }

    #endregion

    public async Task<Result<BlogDto>> UpdateBlogAsync(
        BlogRequestDto requestDto,
        int id,
        CancellationToken cancellationToken
    )
    {
        Result<BlogDto> result;
        try
        {
            var blog = await _context.Tbl_Blogs.FindAsync(
                [id, cancellationToken],
                cancellationToken: cancellationToken
            );
            if (blog is null)
            {
                result = Result<BlogDto>.NotFound();
                goto result;
            }

            blog.BlogTitle = requestDto.BlogTitle;
            blog.BlogAuthor = requestDto.BlogAuthor;
            blog.BlogContent = requestDto.BlogContent;

            _context.Tbl_Blogs.Update(blog);
            await _context.SaveChangesAsync(cancellationToken);

            result = Result<BlogDto>.UpdateSuccess();
        }
        catch (Exception ex)
        {
            result = Result<BlogDto>.Failure(ex);
        }

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
            var blog = await _context.Tbl_Blogs.FindAsync(
                [id, cancellationToken],
                cancellationToken: cancellationToken
            );
            if (blog is null)
            {
                result = Result<BlogDto>.NotFound();
                goto result;
            }

            if (!requestDto.BlogTitle.IsNullOrEmpty())
            {
                blog.BlogTitle += requestDto.BlogTitle;
            }

            if (!requestDto.BlogAuthor.IsNullOrEmpty())
            {
                blog.BlogAuthor += requestDto.BlogAuthor;
            }

            if (!requestDto.BlogContent.IsNullOrEmpty())
            {
                blog.BlogContent += requestDto.BlogContent;
            }

            _context.Tbl_Blogs.Update(blog);
            await _context.SaveChangesAsync(cancellationToken);

            result = Result<BlogDto>.UpdateSuccess();
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
            var blog = await _context.Tbl_Blogs.FindAsync(
                [id, cancellationToken],
                cancellationToken: cancellationToken
            );
            if (blog is null)
            {
                result = Result<BlogDto>.NotFound();
                goto result;
            }

            _context.Tbl_Blogs.Remove(blog);
            await _context.SaveChangesAsync(cancellationToken);

            result = Result<BlogDto>.DeleteSuccess();
        }
        catch (Exception ex)
        {
            result = Result<BlogDto>.Failure(ex);
        }

    result:
        return result;
    }
}
