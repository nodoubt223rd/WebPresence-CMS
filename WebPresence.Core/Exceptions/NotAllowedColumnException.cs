using System;

namespace WebPresence.Core.Exceptions
{
    public class NotAllowedColumnException : WebPresenceException
    {
        public NotAllowedColumnException(string propertyName, Type type) :
                base(string.Format("Sorting and Filtering are not allowed on property {0} of {1}. Are you missing a CanSortAttribute?", propertyName, type.FullName))
        {

        }
    }
}
