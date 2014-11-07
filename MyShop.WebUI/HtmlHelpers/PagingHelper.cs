using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using MyShop.WebUI.Models;

namespace MyShop.WebUI.Helpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PageNavigation pageNavigation,
          Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 1; i <= pageNavigation.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pageNavigation.CurrentPage)
                    tag.AddCssClass("selected");
                result.Append(tag.ToString());
            }

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString PageLinks(this AjaxHelper helper, PageNavigation pageNavigation,
          string currentCategory)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 1; i <= pageNavigation.TotalPages; i++)
            {
                //TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag
                //tag.MergeAttribute("href", pageUrl(i));
                //tag.InnerHtml = i.ToString();
                //if (i == pageNavigation.CurrentPage)
                //    tag.AddCssClass("selected");
                if (i == pageNavigation.CurrentPage)
                    result.Append(helper.ActionLink(i.ToString(), "List", "Products",
                    new { page = i, category = currentCategory},
                    new AjaxOptions() { UpdateTargetId = "productsList" },
                    new { @class = "selected" }
                ));
                else
                result.Append(helper.ActionLink(i.ToString(), "List", "Products",
                    new { page = i, category = currentCategory },
                    new AjaxOptions() { UpdateTargetId = "productsList" }));
            }

            return MvcHtmlString.Create(result.ToString());
        }
    }
}