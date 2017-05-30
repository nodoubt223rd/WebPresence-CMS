using System;

namespace WebPresence.Core.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class MileStoneAttribute : Attribute
    {
    }
}
