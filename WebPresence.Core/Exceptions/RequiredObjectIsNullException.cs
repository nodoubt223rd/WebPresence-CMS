using System;

namespace WebPresence.Core.Exceptions
{
    /// <summary>
    /// Represents a required object is null exception.
    /// </summary>
    [Serializable]
    public class RequiredObjectIsNullException : WebPresenceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sitecore.Exceptions.RequiredObjectIsNullException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public RequiredObjectIsNullException(string message) : base(message)
        {
        }
    }
}
