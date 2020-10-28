using System;
using System.Collections.Generic;
using System.Text;

namespace Book_Api.Core.HelperModels
{
    public class BookFilterModel
    {
        public int TypeId { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public List<int?> Authors { get; set; } = null;
        public List<int?> Publishers { get; set; } = null;
        public decimal? MinPrice { get; set; } = 0;
        public decimal? MaxPrice { get; set; } = 0;
 
    }
}
