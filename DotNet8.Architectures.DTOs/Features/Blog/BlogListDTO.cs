using DotNet8.Architectures.DTOs.Features.PageSetting;

namespace DotNet8.Architectures.DTOs.Features.Blog;

public class BlogListDto
{
    public IEnumerable<BlogDto> DataLst { get; set; }
    public PageSettingModel PageSetting { get; set; }
}
