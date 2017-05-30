using System;

using WebPresence.Common.Resources;

namespace WebPresence.Core.Exceptions
{
    public class PropertyNotFoundException : Exception
    {
        private string _propertyName;
        private Type _type;

        public string PropertyName
        {
            get { return _propertyName; }
        }

        public Type Type
        {
            get { return _type; }
        }

        public PropertyNotFoundException(string propertyName, Type type)
            : base(string.Format(CoreResources.PropertyNotFound, type.GetType(), propertyName))
        {
            _propertyName = propertyName;
            _type = Type;
        }
    }
}
