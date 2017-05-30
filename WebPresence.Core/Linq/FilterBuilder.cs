using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

using WebPresence.Common.Enumerators;
using WebPresence.Common.Resources;
using WebPresence.Core.Diagnostics;

namespace WebPresence.Core.Linq
{
    public class FilterBuilder<T>
    {
        private Expression currentFilter;
        private ParameterExpression param;
        private FilterOperator logicalOperator;
        private FilterBuilder<T> parent = null;

        private static Expression BuildAccessExpressionRec(Expression obj, string[] properties, int level, Type previousType)
        {
            string currentPropertyName = properties[level];

            if (!Assert.ArgumentNotNullOrEmpty(currentPropertyName))
                return null;

            PropertyInfo currentProperty = previousType.GetProperty(currentPropertyName);

            if (!Assert.ArgumentNotNull(currentProperty))
                return null;

            Expression propertyExpression = Expression.MakeMemberAccess(obj, currentProperty);

            if (level >= properties.Length - 1)
                return propertyExpression;
            else
                return BuildAccessExpressionRec(propertyExpression, properties, level + 1, currentProperty.PropertyType);
        }

        public static LambdaExpression BuildAccessExpression(string path)
        {
            if (path == null)
                return null;

            if (string.IsNullOrWhiteSpace(path))
            {
                Expression<Func<T, T>> res = m => m;
                return res;
            }

            string[] properties = path.Split('.');

            if (properties.Length == 0)
                return null;

            ParameterExpression parameter = Expression.Parameter(typeof(T), "m");
            Expression body = BuildAccessExpressionRec(parameter, properties, 0, typeof(T));

            if (body == null)
                return null;

            return Expression.Lambda(body, parameter);
        }

        public FilterBuilder (FilterOperator logicalOperator=FilterOperator.And)
        {
            this.logicalOperator=logicalOperator;
        }

        private Expression istantiateP(Expression exp, object constantValue)
        {
            if (exp == null)
            {
                if (constantValue is TypedConstant)
                {
                    TypedConstant tc = constantValue as TypedConstant;

                    return Expression.Constant(tc.ConstantValue, tc.ConstantType);
                }
                else
                    return Expression.Constant(constantValue);
            }

            BinaryExpression expB = exp as BinaryExpression;

            if (expB != null)
                return expB.Update(istantiateP(expB.Left, constantValue), expB.Conversion, istantiateP(expB.Right, constantValue));

            UnaryExpression expU = exp as UnaryExpression;

            if (expU != null)
                return expU.Update(istantiateP(expU.Operand, constantValue));

            MemberExpression expM = exp as MemberExpression;

            if (expM != null)
                return expM.Update(istantiateP(expM.Expression, constantValue));

            MethodCallExpression expC = exp as MethodCallExpression;

            if (expC != null)
            {
                List<Expression> nArgs = new List<Expression>();

                foreach (Expression e in expC.Arguments)
                    nArgs.Add(istantiateP(e, constantValue));

                return expC.Update(istantiateP(expC.Object, constantValue), nArgs);
            }
            if (exp is ParameterExpression)
            {
                if (constantValue is TypedConstant)
                {
                    TypedConstant tc = constantValue as TypedConstant;

                    return Expression.Constant(tc.ConstantValue, tc.ConstantType);
                }
                else
                    return Expression.Constant(constantValue);
            }

            return exp;
        }

        private LambdaExpression createCall(MethodInfo call, LambdaExpression constantExp, object constantValue, LambdaExpression parameterExpression)
        {            
            return Expression.Lambda(
                Expression.Call(parameterExpression.Body, call, istantiateP(constantExp, constantValue)),
                parameterExpression.Parameters[0]);
        }

        private LambdaExpression createInverseCall(MethodInfo call, LambdaExpression constantExp, object constantValue, LambdaExpression parameterExpression)
        {
            return Expression.Lambda(
                Expression.Call(istantiateP(constantExp, constantValue), call, parameterExpression.Body),
                parameterExpression.Parameters[0]);
        }

        private LambdaExpression createComparison(ExpressionType comparison, LambdaExpression constantExp, object constantValue, LambdaExpression parameterExpression, bool specialString=false)
        {
            if (specialString)
                return Expression.Lambda(
                Expression.MakeBinary(comparison,
                Expression.Call(
                    parameterExpression.Body,
                    typeof(string).GetMethod(
                    "CompareTo",
                    new Type[] { typeof(string) }),
                    istantiateP(constantExp,
                    constantValue)),
                istantiateP(null, 0)),
                parameterExpression.Parameters[0]);

            return Expression.Lambda(
                Expression.MakeBinary(comparison, parameterExpression.Body, istantiateP(constantExp, constantValue)),
                parameterExpression.Parameters[0]);
        }
        
        private Expression adjustP(Expression exp)
        {
            BinaryExpression expB = exp as BinaryExpression;

            if (expB != null)
                return expB.Update(adjustP(expB.Left), expB.Conversion, adjustP(expB.Right));

            UnaryExpression expU = exp as UnaryExpression;

            if (expU != null)
                return expU.Update(adjustP(expU.Operand));

            MemberExpression expM = exp as MemberExpression;

            if (expM != null)
                return expM.Update(adjustP(expM.Expression));

            MethodCallExpression expC = exp as MethodCallExpression;

            if (expC != null)
            {
                List<Expression> nArgs = new List<Expression>();

                foreach (Expression e in expC.Arguments)
                    nArgs.Add(adjustP(e));

                return expC.Update(adjustP(expC.Object), nArgs);
            }

            if (exp is ParameterExpression)
                return param;

            return exp;
        }

        public FilterBuilder<T> Add(FilterCondition condition, string path, dynamic value)
        {
            dynamic fieldSelector = BuildAccessExpression(path);

            if (fieldSelector == null)
                return this;

            return Add(true, condition, fieldSelector, value);
        }

        public FilterBuilder<T> Add<F>(bool toAdd, FilterCondition condition, Expression<Func<T, F>> fieldSelector, dynamic value)
        {
            if (fieldSelector == null)
                throw new ArgumentNullException("fieldSelector");

            if (value == null)
                return this;

            LambdaExpression clause = null;

            switch (condition)
            {
                case FilterCondition.Equal:
                    clause = createComparison(
                        ExpressionType.Equal,
                        null,
                        value,
                        fieldSelector);
                    break;
                case FilterCondition.NotEqual:
                    clause = createComparison(
                        ExpressionType.NotEqual,
                        null,
                        value,
                        fieldSelector);
                    break;
                case FilterCondition.LessThan:
                    clause = createComparison(
                        ExpressionType.LessThan,
                        null,
                        value,
                        fieldSelector, 
                        typeof(F) == typeof(string));
                    break;
                case FilterCondition.LessThanOrEqual:
                    clause = createComparison(
                        ExpressionType.LessThanOrEqual,
                        null,
                        value,
                        fieldSelector, 
                        typeof(F) == typeof(string));
                    break;
                case FilterCondition.GreaterThan:
                    clause = createComparison(
                        ExpressionType.GreaterThan,
                        null,
                        value,
                        fieldSelector,
                        typeof(F) == typeof(string));
                    break;
                case FilterCondition.GreaterThanOrEqual:
                    clause = createComparison(
                        ExpressionType.GreaterThanOrEqual,
                        null,
                        value,
                        fieldSelector, 
                        typeof(F) == typeof(string));
                    break;
                case FilterCondition.StartsWith:
                    clause = createCall(
                        typeof(string).GetMethod("StartsWith", new Type[]{typeof(string)}),
                        null,
                        value,
                        fieldSelector);
                    break;
                case FilterCondition.EndsWith:
                    clause = createCall(
                        typeof(string).GetMethod("EndsWith", new Type[]{ typeof(string) }),
                        null,
                        value,
                        fieldSelector);
                    break;
                case FilterCondition.Contains:
                    clause = createCall(
                        typeof(string).GetMethod("Contains"),
                        null,
                        value,
                        fieldSelector);
                    break;
                default:
                    clause = createInverseCall(
                        value.GetType().GetMethod("Contains"),
                        null,
                        value,
                        fieldSelector);
                    break;
            }
            return Add(toAdd, clause as Expression<Func<T, bool>>);
        }

        public FilterBuilder<T> Add(bool toAdd, Expression<Func<T, bool>> filterClause)
        {
            if (filterClause == null)
                throw new ArgumentNullException("fieldSelector");

            if (!toAdd)
                return this;

            if (filterClause.Parameters == null || filterClause.Parameters.Count != 1)
                throw (new ArgumentException(CoreResources.FilterParameterNumber, "filterClause"));

            if (param == null)
                param = filterClause.Parameters[0];

            else if (filterClause.Parameters[0].Name != param.Name) 
                throw (new ArgumentException(CoreResources.FilterParameterName, "filterClause"));

            if (currentFilter == null)
                currentFilter = filterClause.Body;

            else
            {
                if(logicalOperator == FilterOperator.And)
                    currentFilter = Expression.And(currentFilter, adjustP(filterClause.Body));
                else if (logicalOperator == FilterOperator.Or) 
                    currentFilter = Expression.Or(currentFilter, adjustP(filterClause.Body));
                else
                    currentFilter = Expression.ExclusiveOr(currentFilter, adjustP(filterClause.Body));
            }

            return this;
        }

        public Expression<Func<T, bool>> Get()
        {
            if(currentFilter==null)
                return null;

            return Expression.Lambda<Func<T, bool>>(currentFilter, param);
        }

        public FilterBuilder<T> Open(bool toAdd, FilterOperator logicalOperator)
        {
            FilterBuilder<T> res = new FilterBuilder<T>(logicalOperator);

            res.parent = this;

            return res;
        }

        public FilterBuilder<T> Close(bool toAdd)
        {
            if (parent == null)
                return this;

            if (currentFilter != null && toAdd)
                parent.Add(true, this.Get());

            return parent;
        }
    }
}
