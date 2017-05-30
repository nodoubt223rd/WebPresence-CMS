using System;

namespace WebPresence.Core.Exceptions
{
    public class InvalidDynamicRangeException : Exception
    {
        public InvalidDynamicRangeException(string message)
            : base(message)
        {
        }
    }
}
