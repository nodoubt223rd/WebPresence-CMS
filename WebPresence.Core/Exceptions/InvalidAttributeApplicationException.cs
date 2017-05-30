using System;

namespace WebPresence.Core.Exceptions
{
    public class InvalidAttributeApplicationException : Exception
    {
        public InvalidAttributeApplicationException(string message) : base(message)
        {
        }
    }
}
