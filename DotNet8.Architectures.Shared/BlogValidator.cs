namespace DotNet8.Architectures.Shared;

public class BlogValidator : AbstractValidator<BlogRequestDto>
{
    public BlogValidator()
    {
        RuleFor(x => x.BlogTitle)
            .NotEmpty()
            .WithMessage("Blog Title cannot be empty.")
            .NotNull()
            .WithMessage("Blog Title cannot be null.");

        RuleFor(x => x.BlogAuthor)
            .NotEmpty()
            .WithMessage("Blog Author cannot be empty.")
            .NotNull()
            .WithMessage("Blog Author cannot be null.");

        RuleFor(x => x.BlogContent)
            .NotEmpty()
            .WithMessage("Blog Content cannot be empty.")
            .NotNull()
            .WithMessage("Blog Content cannot be null.");
    }
}
