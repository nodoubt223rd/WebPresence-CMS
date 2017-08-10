using System;

namespace WebPresence.Core.UI.Html
{
    public static class HtmlStringExtensions
    {
        public static string AsAttribute(this string value, string attributeName)
        {
            if (string.IsNullOrEmpty(attributeName))
                throw new ArgumentNullException("attributeName");

            return string.IsNullOrEmpty(value) ? "" : $" {attributeName}=\"{value}\"";
        }

        public static string AsClassAttribute(this string value)
        {
            return value.AsAttribute("class");
        }
    }
}
