namespace DotNet8.Architectures.ModularMonolithic.Modules.Application.Features.Blog.GetBlogList;

public class GetBlogListQuery : IRequest<Result<BlogListDtoV1>>
{
    public int PageNo { get; set; }
    public int PageSize { get; set; }

    public GetBlogListQuery(int pageNo, int pageSize)
    {
        PageNo = pageNo;
        PageSize = pageSize;
    }
}
