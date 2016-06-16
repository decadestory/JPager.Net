using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace JPager.Net
{
    internal static class Exts
    {
        public static string GetUrl(this string url, int curIndex, int reps)
        {
            return url.Replace("pageindex=" + curIndex.ToString(), "pageindex=" + reps.ToString());
        }
    }

    public class PagerResult<T>
    {
        public int Code { get; set; }
        public int Total { get; set; }
        public IEnumerable<T> DataList { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string RequestUrl { get; set; }

        /// <summary>
        /// 分页页码Html
        /// </summary>
        /// <param name="cssClass">默认样式：jpager</param>
        /// <param name="size">分页页码长度：默认10</param>
        /// <returns></returns>
        public string PagerHtml(string cssClass="jpager",int size=10)
        {
            if (PageIndex == 0) PageIndex = 1;
            if (RequestUrl.IndexOf("?", StringComparison.Ordinal) == -1) RequestUrl += "?pageindex=1";
            else
            if (RequestUrl.IndexOf("&pageindex", StringComparison.Ordinal) == -1&& RequestUrl.IndexOf("?pageindex", StringComparison.Ordinal) == -1) RequestUrl += "&pageindex=1";
            
            var html = new StringBuilder();
            html.AppendFormat("<span class='{0}'>", cssClass);
            var pageLen = Math.Ceiling((double)Total / PageSize);
            html.AppendFormat("<a href='{0}'> 首页 </a>", RequestUrl.GetUrl(PageIndex,1));
            html.AppendFormat("<a href='{0}'> 上页 </a>", RequestUrl.GetUrl(PageIndex, PageIndex < 2 ? 1 : PageIndex - 1));

            var si = PageIndex <= (size/2+1) ? 1 : PageIndex - size/2;
            var ei = si + size-1;

            while (si <= pageLen && si <= ei)
                html.AppendFormat(
                    si == PageIndex
                        ? "<a cur href='{0}'> {1} </a>"
                        : "<a href='{0}'> {1} </a>", RequestUrl.GetUrl(PageIndex, si), si++);

            html.AppendFormat("<a href='{0}'> 下页 </a>", RequestUrl.GetUrl(PageIndex, (int)(PageIndex > pageLen - 1 ? pageLen : PageIndex + 1)));

            html.AppendFormat("<a href='{0}'> 尾页 </a>",
                Math.Abs(Total) <= 0 
                ? RequestUrl.GetUrl(PageIndex, 1) 
                : RequestUrl.GetUrl(PageIndex, (int) pageLen));

            html.Append(@"</span>");
            return html.ToString();

        }
        
    }

}
