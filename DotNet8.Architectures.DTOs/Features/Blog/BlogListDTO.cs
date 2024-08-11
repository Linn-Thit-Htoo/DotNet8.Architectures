using DotNet8.Architectures.DTOs.Features.PageSetting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Architectures.DTOs.Features.Blog
{
    public class BlogListDto
    {
        public IEnumerable<BlogDto> DataLst { get; set; }
        public PageSettingModel PageSetting { get; set; }
    }
}
