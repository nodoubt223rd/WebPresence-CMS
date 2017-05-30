using System;

namespace WebPresence.Core.Exceptions
{
    /// <summary>
    /// Represents a unknown type exception.
    /// </summary>
    [Serializable]
    public class UnknownTypeException : WebPresenceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:WebPresence.Core.Exceptions.UnknownTypeException" /> class.
        /// </summary>
        public UnknownTypeException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WebPresence.Core.Exceptions.UnknownTypeException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public UnknownTypeException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WebPresence.Core.Exceptions.UnknownTypeException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innnerException">The innner exception.</param>
        public UnknownTypeException(string message, Exception innnerException) : base(message, innnerException)
        {
        }
    }
}
