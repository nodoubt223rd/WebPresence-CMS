using System;

namespace WebPresence.Core
{
    /// <summary>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface, AllowMultiple = false, Inherited = true)]
    public class CannotApplyEqualityOperatorAttribute : Attribute
    {
        public CannotApplyEqualityOperatorAttribute()
        {
        }
    }
}
