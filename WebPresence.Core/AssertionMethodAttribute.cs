using System;

namespace WebPresence.Core
{
    /// <summary>
    /// Implements the NullableAttribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class AssertionMethodAttribute : Attribute
    {
        public AssertionMethodAttribute()
        {
        }
    }
}
