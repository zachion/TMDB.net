using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace TMDB.net.Class
{
    public static class PagingHelper
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            string anchorInnerHtml = "";
            for (int i = 1; i <= pagingInfo.totalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                anchorInnerHtml = AnchorInnerHtml(i, pagingInfo);

                if (anchorInnerHtml == "..")
                    tag.MergeAttribute("href", "#");
                else
                    tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = anchorInnerHtml;
                if (i == pagingInfo.currentPage)
                {
                    tag.AddCssClass("active");
                }
                tag.AddCssClass("paging");
                if (anchorInnerHtml != "")
                    result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }

        public static string AnchorInnerHtml(int i, PagingInfo pagingInfo)
        {
            string anchorInnerHtml = "";
            if (pagingInfo.totalPages <= 10)
                anchorInnerHtml = i.ToString();
            else
            {
                if (pagingInfo.currentPage <= 5)
                {
                    if ((i <= 8) || (i == pagingInfo.totalPages))
                        anchorInnerHtml = i.ToString();
                    else if (i == pagingInfo.totalPages - 1)
                        anchorInnerHtml = "..";
                }
                else if ((pagingInfo.currentPage > 5) && (pagingInfo.totalPages - pagingInfo.currentPage >= 5))
                {
                    if ((i == 1) || (i == pagingInfo.totalPages) || ((pagingInfo.currentPage - i >= -3) && (pagingInfo.currentPage - i <= 3)))
                        anchorInnerHtml = i.ToString();
                    else if ((i == pagingInfo.currentPage - 4) || (i == pagingInfo.currentPage + 4))
                        anchorInnerHtml = "..";
                }
                else if (pagingInfo.totalPages - pagingInfo.currentPage < 5)
                {
                    if ((i == 1) || (pagingInfo.totalPages - i <= 7))
                        anchorInnerHtml = i.ToString();
                    else if (pagingInfo.totalPages - i == 8)
                        anchorInnerHtml = "..";
                }
            }
            return anchorInnerHtml;
        }
    }
}