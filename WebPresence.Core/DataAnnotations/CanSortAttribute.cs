using System;
using System.Collections;
using System.Linq.Expressions;

using WebPresence.Common.Enumerators;
using WebPresence.Common.Logging;
using WebPresence.Common.Resources;
using WebPresence.Core.Diagnostics;

namespace WebPresence.Core.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class CanSortAttribute : Attribute
    {
        public FilterCondition Allow { get; set; }
        public FilterCondition Deny { get; set; }

        public CanSortAttribute()
        {
            Allow = FilterCondition.Equal |
                FilterCondition.LessThan |
                FilterCondition.LessThanOrEqual |
                FilterCondition.GreaterThan |
                FilterCondition.GreaterThanOrEqual |
                FilterCondition.NotEqual |
                FilterCondition.StartsWith |
                FilterCondition.EndsWith |
                FilterCondition.IsContainedIn |
                FilterCondition.Contains;

            Deny = FilterCondition.IsContainedIn | FilterCondition.Contains;
        }

        public bool Allowed(FilterCondition condition)
        {

            return (condition & Allow & (~Deny)) == condition;

        }

        public FilterCondition Filter(FilterCondition conditions)
        {
            return conditions & Allow & (~Deny);
        }

        public static FilterCondition AllowedForProperty(FilterCondition conditions, Type type, string propertyName)
        {
            if (!Assert.ArgumentNotNull(type))
                throw new ArgumentException("type");

            Assert.IsNotNullOrEmpty(propertyName, "propertyName");

            PropertyAccessor pa = null;

            try
            {
                pa = new PropertyAccessor(propertyName, type);
            }
            catch
            {
                LogManager.Instance.LogError(string.Format(CoreResources.PropertyNameTypeError, propertyName, type.Name));
            }

            if (pa == null)
                throw new ArgumentException("propertyName");

            type = pa.Property.PropertyType;

            CanSortAttribute[] attributes = pa[typeof(CanSortAttribute)] as CanSortAttribute[];

            if (attributes.Length == 0)
                return FilterCondition.None;

            if (type == typeof(bool) || type == typeof(bool?))
            {
                conditions = conditions & FilterCondition.Equal;

                return attributes[0].Filter(conditions);
            }

            if (type != typeof(string))
            {
                conditions = conditions & (~(FilterCondition.StartsWith |  FilterCondition.EndsWith));
            }

            if (!typeof(IEnumerable).IsAssignableFrom(type))
            {
                conditions = conditions & (~FilterCondition.Contains);
            }

            return attributes[0].Filter(conditions);
        }

        public static FilterCondition AllowedForProperty(Type type, string propertyName)
        {
            if (!Assert.ArgumentNotNull(type))
                throw new ArgumentException("type");

            Assert.IsNotNullOrEmpty(propertyName, "propertyName");

            PropertyAccessor pa = null;
            try
            {
                pa = new PropertyAccessor(propertyName, type);
            }
            catch
            {
                LogManager.Instance.LogError(string.Format(CoreResources.PropertyNameTypeError, propertyName, type.Name));
            }

            if (pa == null)
                throw new ArgumentException("propertyName");

            type = pa.Property.PropertyType;

            CanSortAttribute[] attributes = pa[typeof(CanSortAttribute)] as CanSortAttribute[];

            if (attributes.Length == 0)
                return FilterCondition.None;

            FilterCondition conditions = attributes[0].Allow & (~attributes[0].Deny);

            if (type == typeof(bool) || type == typeof(bool?))
            {
                conditions = conditions & FilterCondition.Equal;

                return conditions;
            }

            if (type != typeof(string))
            {
                conditions = conditions & (~(FilterCondition.StartsWith | FilterCondition.EndsWith));
            }

            if (!typeof(IEnumerable).IsAssignableFrom(type))
            {
                conditions = conditions & (~FilterCondition.Contains);
            }

            return conditions;
        }

        public static FilterCondition AllowedForProperty<T, F>(Expression<Func<T, F>> field)
        {
            if (field == null)
                throw new ArgumentException("field");

            return AllowedForProperty(typeof(T), FieldExpressionHelper.GetExpressionText(field));
        }

        public static FilterCondition AllowedForProperty<T, F>(FilterCondition conditions, Expression<Func<T, F>> field)
        {
            if (field == null)
                throw new ArgumentException("field");

            return AllowedForProperty(conditions, typeof(T), FieldExpressionHelper.GetExpressionText(field));
        }
    }
}
