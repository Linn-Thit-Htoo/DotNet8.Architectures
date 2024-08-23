namespace DotNet8.Architectures.Hexagonal.Application.Features.Blog.CreateBlog;

public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, Result<BlogDto>>
{
    private readonly IBlogPort _blogPort;

    public CreateBlogCommandHandler(IBlogPort blogPort)
    {
        _blogPort = blogPort;
    }

    public async Task<Result<BlogDto>> Handle(
        CreateBlogCommand request,
        CancellationToken cancellationToken
    )
    {
        Result<BlogDto> result;

        if (request.requestDto.BlogTitle.IsNullOrEmpty())
        {
            result = Result<BlogDto>.Failure("Blog Title cannot be empty.");
            goto result;
        }

        if (request.requestDto.BlogAuthor.IsNullOrEmpty())
        {
            result = Result<BlogDto>.Failure("Blog Author cannot be empty.");
            goto result;
        }

        if (request.requestDto.BlogContent.IsNullOrEmpty())
        {
            result = Result<BlogDto>.Failure("Blog Content");
            goto result;
        }

        result = await _blogPort.AddBlogAsync(request.requestDto, cancellationToken);

    result:
        return result;
    }
}
