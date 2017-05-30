using System;

namespace WebPresence.Core.Exceptions
{ 
    /// <summary>
  /// Represents a invalid value exception.
  /// </summary>
    [Serializable]
    public class InvalidValueException : WebPresenceException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sitecore.Exceptions.InvalidValueException" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public InvalidValueException(string message) : base(message)
        {
        }
    }
}
