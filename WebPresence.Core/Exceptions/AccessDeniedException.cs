using System;

namespace WebPresence.Core.Exceptions
{
    /// <summary>
    /// Represents a AccessDenied exception.
    /// </summary>
    [Serializable]
    public class AccessDeniedException : WebPresenceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:WebPresence.Core.Exceptions.AccessDeniedException" /> class.
        /// </summary>
        public AccessDeniedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WebPresence.Core.Exceptions.AccessDeniedException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public AccessDeniedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WebPresence.Core.Exceptions.AccessDeniedException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innnerException">The innner exception.</param>
        public AccessDeniedException(string message, Exception innnerException) : base(message, innnerException)
        {
        }
    }
}
