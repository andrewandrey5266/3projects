using System;
using System.Text;
using System.Web.Mvc;
using SportsStore.ViewModel.Models;
namespace SportsStore.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(
            this HtmlHelper html,
            PagingInfo pagingInfo)
            //Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
           
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a"); // Construct an <a> tag
               tag.InnerHtml = i.ToString();
               tag.Attributes.Add("href", "");
               tag.Attributes.Add("ng-click", "getCategory(0, " + i + ")");
                if (i == pagingInfo.CurrentPage)
                    tag.AddCssClass("selected");
                result.Append(tag.ToString());

               //
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}