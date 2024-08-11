using DotNet8.Architectures.DbService.Entities;
using DotNet8.Architectures.DTOs.Features.Blog;

namespace DotNet8.Architectures.Extensions;

public static class Extension
{
    public static BlogDto ToDto(this Tbl_Blog dataModel)
    {
        return new BlogDto
        {
            BlogId = dataModel.BlogId,
            BlogTitle = dataModel.BlogTitle,
            BlogAuthor = dataModel.BlogAuthor,
            BlogContent = dataModel.BlogContent
        };
    }

    public static Tbl_Blog ToEntity(this CreateBlogDto blogDto)
    {
        return new Tbl_Blog
        {
            BlogTitle = blogDto.BlogTitle,
            BlogAuthor = blogDto.BlogAuthor,
            BlogContent = blogDto.BlogContent
        };
    }
}
