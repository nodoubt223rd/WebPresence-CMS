using System;

namespace WebPresence.Core.Exceptions
{
    public class ForbiddenException : Exception
    {
        public ForbiddenException(string errorMessage) : base(errorMessage)
        {
        }
    }
}
