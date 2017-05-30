using System;

namespace WebPresence.Core.Exceptions
{
    public class NotAllowedFilteringException : WebPresenceException
    {
        public NotAllowedFilteringException(string operationName, string propertyName, Type type) :
                base(string.Format("Filtering operation {0} is not allowed on property {1} of {2}.", operationName, propertyName, type.FullName))
        {

        }
    }
}
