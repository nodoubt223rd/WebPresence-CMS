using System;
using System.Diagnostics;

namespace WebPresence.Core
{
    /// <summary>
    /// Implements the CanBeBullAttribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Delegate, AllowMultiple = false, Inherited = true)]
    [Conditional("NOP")]
    public sealed class CanBeNullAttribute : Attribute
    {
        public CanBeNullAttribute()
        {
        }
    }
}
