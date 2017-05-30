using System;

namespace WebPresence.Core
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class StringFormatMethodAttribute : Attribute
    {
        private readonly string _formatParameterName;

        /// <summary>
        /// Gets the name of the format parameter.
        /// </summary>
        /// <value>The name of the format parameter.</value>
        public string FormatParameterName
        {
            get
            {
                return this._formatParameterName;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sitecore.StringFormatMethodAttribute" /> class.
        /// </summary>
        /// <param name="formatParameterName">Name of the format parameter.</param>
        public StringFormatMethodAttribute(string formatParameterName)
        {
            this._formatParameterName = formatParameterName;
        }
    }
}
