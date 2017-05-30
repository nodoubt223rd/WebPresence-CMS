using System;

namespace WebPresence.Core
{
    /// <summary>
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = true)]
    public class InvokerParameterNameAttribute : Attribute
    {
        public InvokerParameterNameAttribute()
        {
        }
    }
}
