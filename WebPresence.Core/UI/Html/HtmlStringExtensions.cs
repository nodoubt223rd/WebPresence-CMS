using System;

namespace WebPresence.Core.UI.Html
{
    public static class HtmlStringExtensions
    {
        public static string AsAttribute(this string value, string attributeName)
        {
            if (string.IsNullOrEmpty(attributeName))
                throw new ArgumentNullException("attributeName");

            return string.IsNullOrEmpty(value) ? "" : string.Format(" {0}=\"{1}}\"", attributeName, value);
        }

        public static string AsCalssAttribute(this string value)
        {
            return value.AsAttribute("class");
        }
    }
}
