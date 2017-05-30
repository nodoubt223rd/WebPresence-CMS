using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

using WebPresence.Core.Diagnostics;

namespace WebPresence.Core.Utilities
{
    /// <summary>Implements a utility class for manipulating strings.</summary>
    public sealed class StringUtils
    {
        private static Regex m_removeTagsRegex;

        static StringUtils()
        {
            m_removeTagsRegex = new Regex("<[^>]*>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
        }

        public StringUtils()
        {
        }

        /// <summary>
        /// Arrays to string.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <returns></returns>
        public static string ArrayToString(Array array, char delimiter)
        {
            Assert.ArgumentNotNull(array, "array");
            string str = "";
            for (int i = 0; i < array.Length; i++)
            {
                object value = array.GetValue(i);
                if (value != null)
                {
                    if (i > 0)
                    {
                        str = string.Concat(str, delimiter);
                    }
                    str = string.Concat(str, value.ToString());
                }
            }
            return str;
        }

        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The string.</returns>
        /// <contract>
        ///   <requires name="value" condition="none" />
        ///   <ensures condition="nullable" />
        /// </contract>
        public static string GetString(object value)
        {
            return StringUtils.GetString(value, string.Empty);
        }

        /// <summary>
        /// Uppercases the first letter of a string and
        /// lowercases the remaining letters.
        /// </summary>
        /// <param name="text">A string.</param>
        /// <returns>The capitalized string.</returns>
        /// <remarks>Sentences are not taken into account.</remarks>
        /// <example>
        /// 	<code>
        /// string text = MainUtil.Capitalize("HELLO WORLD."); // "Hello world"
        /// string text = MainUtil.Capitalize("HELLO. HOW ARE YOU?"); // "Hello. how are you?"
        /// </code>
        /// </example>
        public static string Capitalize(string text)
        {
            string str = text.Trim();
            if (str.Length == 0)
            {
                return "";
            }
            return string.Concat(str.Substring(0, 1).ToUpperInvariant(), str.Substring(1).ToLowerInvariant());
        }

        /// <summary>
        /// Clips a string at a certain length.
        /// </summary>
        /// <param name="text">The text that will be clipped.</param>
        /// <param name="length">The maximum length of the returned string.</param>
        /// <param name="ellipsis">Indicates if the string should have en ellipsis (...) appended</param>
        /// <returns>The clipped string.</returns>
        /// <example>
        /// 	<code>
        /// string s0 = StringUtil.Clip("Hello world", 5, false); // "Hello"
        /// string s1 = StringUtil.Clip("Hello world", 5, true);  // "He..."
        /// </code>
        /// </example>
        public static string Clip(string text, int length, bool ellipsis)
        {
            Error.AssertString(text, "text", true);
            Error.AssertInt(length, "length", false, false);
            text = text.Replace("&nbsp;", " ").Replace("  ", " ");
            if (text.Length > length)
            {
                if (ellipsis)
                {
                    length = length - 3;
                }
                int num = text.LastIndexOf(" ", length, StringComparison.InvariantCulture);
                if (num < 0)
                {
                    num = length;
                }
                text = text.Substring(0, num);
                if (ellipsis)
                {
                    text = string.Concat(text, "...");
                }
            }
            return text;
        }

        /// <summary>
        /// Gets the string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The string.</returns>
        /// <contract>
        /// 	<requires name="value" condition="none" />
        /// 	<requires name="defaultValue" condition="none" />
        /// 	<ensures condition="nullable" />
        /// </contract>
        public static string GetString(object value, string defaultValue)
        {
            if (value == null)
            {
                return defaultValue;
            }
            string str = value.ToString();
            if (str.Length > 0)
            {
                return str;
            }
            return defaultValue;
        }

        /// <summary>
        /// Gets a non-empty string from a list.
        /// </summary>
        /// <param name="values">The values.</param>
        /// <returns>The string.</returns>
        /// <contract>
        ///   <requires name="values" condition="not null" />
        ///   <ensures condition="not null" />
        /// </contract>
        public static string GetString(params string[] values)
        {
            Assert.ArgumentNotNull(values, "values");

            string[] strArrays = values;

            for (int i = 0; i < (int)strArrays.Length; i++)
            {
                string str = strArrays[i];
                if (!string.IsNullOrEmpty(str))
                {
                    return str;
                }
            }

            return string.Empty;
        }
    }
}
