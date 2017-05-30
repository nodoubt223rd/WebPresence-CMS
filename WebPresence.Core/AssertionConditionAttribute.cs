using System;

namespace WebPresence.Core
{
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple=false, Inherited=true)]
    public class AssertionConditionAttribute : Attribute
    {
        private readonly AssertionConditionType _conditionType;

        /// <summary>
        /// Gets the type of the condition.
        /// </summary>
        public AssertionConditionType ConditionType
        {
            get
            {
                return this._conditionType;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WebPresence.Core.AssertionConditionAttribute"/> class.
        /// </summary>
        /// <param name="conditiontype"></param>
        public AssertionConditionAttribute(AssertionConditionType conditiontype)
        {
            this._conditionType = conditiontype;
        }
    }
}
