﻿using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

using WebPresence.Common.Security.Validation;

namespace WebPresence.Common.Text
{
    public static class StringExtensions
    {
        private static readonly Regex cleanWhitespace = new Regex(@"\s+", RegexOptions.Compiled | RegexOptions.Singleline);

        public static string IsRequired(this string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                throw new ValidationException(string.Format("String is required: {0}", s));
            }

            return s;
        }

        public static string CleanHtmlTags(this string s)
        {
            Regex exp = new Regex(
                "<[^<>]*>",
                RegexOptions.Compiled
                );

            return exp.Replace(s, "");
        }

        public static string CleanText(this string s)
        {
            return Microsoft.Security.Application.Encoder.HtmlEncode(s);
        }

        public static string CleanHtml(this string s)
        {
            //AntiXss library from Microsoft
            //(http://codeplex.com/antixss)
            string encodedText = Microsoft.Security.Application.Encoder.HtmlEncode(s);
            //convert line breaks into an HTML break tag
            return encodedText.Replace("&#13;&#10;", "<br />");
        }

        public static string CleanAttribute(this string s)
        {

            return Microsoft.Security.Application.Encoder.HtmlEncode(s);
        }

        public static string CleanHref(this string s)
        {
            return HttpUtility.HtmlAttributeEncode(s);
        }

        public static string CleanWhiteSpace(this string s)
        {
            return cleanWhitespace.Replace(s, " ");
        }

        public static string CleanCommentBody(this string s)
        {
            return s.CleanHtmlTags().CleanHtml().AutoAnchorEncode();
        }

        public static string CleanPostBody(this string s)
        {
            return s.CleanHtml().CleanHref().CleanAttribute();
        }

        private static readonly Regex uriEncodedRegex = new Regex("(^|[^\\w'\"]|\\G)(?<uri>(?:https?|ftp)&#58;&#47;&#47;(?:[^./\\s'\"<)\\]]+\\.)+[^./\\s'\"<)\\]]+(?:&#47;.*?)?)(\\.[\\s<'\"]|[\\s,<'\"]|$)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public static string AutoAnchorEncode(this string s)
        {
            MatchCollection uriMatches = uriEncodedRegex.Matches(s);

            foreach (Match uriMatch in uriMatches)
            {
                string encodedUri = uriMatch.Groups["uri"].Value;

                if (!string.IsNullOrEmpty(encodedUri))
                {
                    string uri = HttpUtility.HtmlDecode(encodedUri);
                    s = s.Replace(encodedUri, string.Format("<a href=\"{0}\">{1}</a>", uri.CleanHref(), uri.CleanText()));
                }
            }

            return s;
        }

        public static bool GuidTryParse(this string s, out Guid result)
        {
            if (s == null)
            {
                throw new ArgumentNullException("s");
            }

            try
            {
                result = new Guid(s);
                return true;
            }
            catch (FormatException)
            {
                result = Guid.Empty;
                return false;
            }
            catch (OverflowException)
            {
                result = Guid.Empty;
                return false;
            }
        }

        public static string ComputeHash(this string value)
        {
            string hash = value;

            if (value != null)
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                byte[] data = Encoding.ASCII.GetBytes(value);
                data = md5.ComputeHash(data);
                hash = "";
                for (int i = 0; i < data.Length; i++)
                {
                    hash += data[i].ToString("x2");
                }
            }

            return hash;
        }
    }
}
