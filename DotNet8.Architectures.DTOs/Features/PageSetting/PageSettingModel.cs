using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNet8.Architectures.DTOs.Features.PageSetting
{
    public class PageSettingModel
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public int TotalCount { get; set; }

        public PageSettingModel(int pageNo, int pageSize, int pageCount, int totalCount)
        {
            PageNo = pageNo;
            PageSize = pageSize;
            PageCount = pageCount;
            TotalCount = totalCount;
        }
    }
}
