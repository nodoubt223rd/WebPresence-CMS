using System;

namespace WebPresence.Core.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CollectionMaxLengthAttribute : Attribute
    {
        public int Max { get; set; }
    }
}
