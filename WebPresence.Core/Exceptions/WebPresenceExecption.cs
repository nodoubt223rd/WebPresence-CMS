using System;

namespace WebPresence.Core.Exceptions
{
    /// <summary>
    /// Defines the basic properties and functionality of a WebPresence exception.
    /// </summary>
    [Serializable]
    public abstract class WebPresenceException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:WebPresence.Core.Exceptions.WebPresenceException" /> class.
        /// </summary>
        protected WebPresenceException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WebPresence.Core.Exceptions.WebPresenceException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        protected WebPresenceException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WebPresence.Core.Exceptions.WebPresenceException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        protected WebPresenceException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
