using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JPager.Net
{
    public class PagerInBase
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Skip => (PageIndex - 1) * PageSize;
        public string RequetUrl => System.Web.HttpContext.Current.Request.Url.OriginalString;

        public PagerInBase()
        {
            if (PageIndex == 0) PageIndex = 1;
            if (PageSize == 0) PageSize = 10;
        }
    }
}
