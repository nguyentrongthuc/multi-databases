using System;
using System.Text.RegularExpressions;

namespace ServiceCore.Utilities
{
    public class HtmlUtility
    {
        public static string RemoveHtmlTags(string HtmlString)
        {
            HtmlString = HtmlString.Replace("&nbsp;", string.Empty);
            return Regex.Replace(HtmlString, "<.*?>", String.Empty);
        }
    }
}