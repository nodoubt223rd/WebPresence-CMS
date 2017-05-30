using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using WebPresence.Common.Enumerators;
using WebPresence.Core.DataAnnotations;
using WebPresence.Core.Exceptions;

namespace WebPresence.Core.Linq
{
    public class SafeQueryProvider : IQueryProvider
    {
        protected Expression _lastModified;
        protected IQueryProvider _inner;
        private bool andOnly;

        public virtual IQueryable<TElement> CreateQuery<TElement>(System.Linq.Expressions.Expression expression)
        {
            CheckExpression(expression);
            IQueryable<TElement> query = _inner.CreateQuery<TElement>(expression);
            SafeQueryProvider prov = new SafeQueryProvider(query.Provider, expression, andOnly);
            return new SafeQuery<TElement>(query, prov);
        }

        public virtual IQueryable CreateQuery(System.Linq.Expressions.Expression expression)
        {
            CheckExpression(expression);

            IQueryable query = _inner.CreateQuery(expression);
            SafeQueryProvider prov = new SafeQueryProvider(query.Provider, expression, andOnly);
            Type elementType = TypeSystem.GetElementType(expression.Type);

            try
            {
                return (IQueryable)Activator.CreateInstance(typeof(SafeQuery<>).MakeGenericType(elementType), new object[] { query, prov });
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
        }

        public TResult Execute<TResult>(System.Linq.Expressions.Expression expression)
        {
            return _inner.Execute<TResult>(expression);
        }

        public TResult IExecute<TResult>(Expression expression)
        {
            return _inner.Execute<TResult>(expression);
        }

        public object Execute(System.Linq.Expressions.Expression expression)
        {
            return _inner.Execute(expression);
        }        

        public SafeQueryProvider(IQueryProvider provider, Expression initialExpression, bool andOnly = false)
        {
            _inner = provider ?? throw new ArgumentNullException("provider");
            _lastModified = initialExpression ?? throw new ArgumentNullException("initialExpression");
            this.andOnly = andOnly;
        }

        protected virtual void CheckExpression(Expression expression)
        {
            if (expression == _lastModified)
                return;

            MethodCallExpression mc = expression as MethodCallExpression;

            if (mc == null)
                return;

            if (mc.Method.DeclaringType == typeof(Queryable))
            {
                if (mc.Method.Name == "Where")
                {
                    LambdaExpression lambda = GetLambda(mc.Arguments[1]);

                    if (lambda.Parameters.Count != 1)
                        throw new NotAllowedExpressionException();

                    CheckFilter(lambda.Body, lambda.Parameters[0].Type);
                    CheckExpression(mc.Arguments[0]);
                }
                else if (mc.Method.Name == "ThenBy")
                {
                }
                else if (mc.Method.Name == "OrderBy" || mc.Method.Name == "OrderByDescending" || mc.Method.Name == "ThenByDescending")
                {
                    LambdaExpression lambda = GetLambda(mc.Arguments[1]);

                    if (lambda.Parameters.Count != 1)
                        throw new NotAllowedExpressionException();

                    CheckSorting(lambda.Body, lambda.Parameters[0].Type);
                    CheckExpression(mc.Arguments[0]);
                }
                else if (mc.Method.Name == "Take" || mc.Method.Name == "Skip")
                    CheckExpression(mc.Arguments[0]);
                else
                    throw new NotAllowedExpressionException(mc.Method.Name);
            }
        }

        protected FilterCondition InvertCondition(FilterCondition c)
        {
            if (c == FilterCondition.GreaterThan)
                return FilterCondition.LessThan;

            if (c == FilterCondition.GreaterThanOrEqual)
                return FilterCondition.LessThanOrEqual;

            if (c == FilterCondition.LessThan)
                return FilterCondition.GreaterThan;

            if (c == FilterCondition.LessThanOrEqual)
                return FilterCondition.GreaterThanOrEqual;

            else return c;
        }

        protected void CheckFilter(Expression expression, Type originalType, FilterCondition operation = FilterCondition.None, bool isAllowed = true)
        {
            if (expression.NodeType == ExpressionType.And ||
                expression.NodeType == ExpressionType.AndAlso || ((!andOnly) && (
                expression.NodeType == ExpressionType.Or ||
                expression.NodeType == ExpressionType.ExclusiveOr ||
                expression.NodeType == ExpressionType.OrElse))
                )
            {
                BinaryExpression e = expression as BinaryExpression;

                CheckFilter(e.Left, originalType);
                CheckFilter(e.Right, originalType);
            }
            else if (expression.NodeType == ExpressionType.Conditional)
            {
                ConditionalExpression e = expression as ConditionalExpression;

                CheckFilter(e.IfTrue, originalType);
                CheckFilter(e.IfFalse, originalType);
                CheckFilter(e.Test, originalType);
            }
            else if (expression.NodeType == ExpressionType.Convert)
            {
                UnaryExpression e = expression as UnaryExpression;

                CheckFilter(e.Operand, originalType, operation);
            }
            else if (expression.NodeType == ExpressionType.Equal)
            {
                BinaryExpression e = expression as BinaryExpression;

                CheckFilter(e.Left, originalType, FilterCondition.Equal);
                CheckFilter(e.Right, originalType, FilterCondition.Equal);
            }
            else if (expression.NodeType == ExpressionType.NotEqual)
            {
                BinaryExpression e = expression as BinaryExpression;

                CheckFilter(e.Left, originalType, FilterCondition.NotEqual);
                CheckFilter(e.Right, originalType, FilterCondition.NotEqual);
            }
            else if (expression.NodeType == ExpressionType.LessThan)
            {
                BinaryExpression e = expression as BinaryExpression;

                CheckFilter(e.Left, originalType, FilterCondition.LessThan);
                CheckFilter(e.Right, originalType, FilterCondition.GreaterThan);
            }
            else if (expression.NodeType == ExpressionType.LessThanOrEqual)
            {
                BinaryExpression e = expression as BinaryExpression;

                CheckFilter(e.Left, originalType, FilterCondition.LessThanOrEqual);
                CheckFilter(e.Right, originalType, FilterCondition.GreaterThanOrEqual);
            }
            else if (expression.NodeType == ExpressionType.GreaterThan)
            {
                BinaryExpression e = expression as BinaryExpression;

                CheckFilter(e.Left, originalType, FilterCondition.GreaterThan);
                CheckFilter(e.Right, originalType, FilterCondition.LessThan);
            }
            else if (expression.NodeType == ExpressionType.GreaterThanOrEqual)
            {
                BinaryExpression e = expression as BinaryExpression;

                CheckFilter(e.Left, originalType, FilterCondition.GreaterThanOrEqual);
                CheckFilter(e.Right, originalType, FilterCondition.LessThanOrEqual);
            }
            else if (expression.NodeType == ExpressionType.Call)
            {
                MethodCallExpression e = expression as MethodCallExpression;
                FilterCondition op = FilterCondition.None;

                if (e.Method.Name == "Contains")
                {
                    CheckFilter(e.Object, originalType, FilterCondition.Contains);
                    CheckFilter(e.Arguments[0], originalType, FilterCondition.IsContainedIn);

                    return;
                }
                else if (e.Method.Name == "Compare")
                {
                    CheckFilter(e.Arguments[0], originalType, operation);
                    CheckFilter(e.Arguments[1], originalType, InvertCondition(operation));

                    return;
                }
                else if (e.Method.Name == "StartsWith")
                {
                    op = FilterCondition.StartsWith;
                    CheckFilter(e.Object, originalType, op);
                    CheckFilter(e.Arguments[0], originalType, op, false);

                    return;
                }
                else if (e.Method.Name == "EndsWith")
                {
                    op = FilterCondition.EndsWith;
                    CheckFilter(e.Object, originalType, op);
                    CheckFilter(e.Arguments[0], originalType, op, false);

                    return;
                }

                throw new NotAllowedExpressionException();
            }
            else if (expression.NodeType == ExpressionType.Not && (!andOnly))
            {
                UnaryExpression e = expression as UnaryExpression;

                CheckFilter(e.Operand, originalType);
            }
            else if (expression.NodeType == ExpressionType.Constant || expression.NodeType == ExpressionType.Quote)
            {
                return;
            }
            else if (expression.NodeType == ExpressionType.MemberAccess)
            {

                if (operation == FilterCondition.None)
                    throw new NotAllowedExpressionException();

                Type type;
                PropertyInfo property;

                VisitMemeberAccess(expression, originalType, out type, out property);

                if (property == null)
                    return;

                if (!isAllowed)
                    throw new NotAllowedExpressionException();

                CanSortAttribute[] cs = property.GetCustomAttributes(typeof(CanSortAttribute), true) as CanSortAttribute[];
                if (cs == null || cs.Length == 0)
                {
                    MetadataTypeAttribute[] mt = type.GetCustomAttributes(typeof(MetadataTypeAttribute), true) as MetadataTypeAttribute[];
                    if (mt != null && mt.Length != 0)
                    {
                        property = mt[0].MetadataClassType.GetProperty(property.Name);
                        if (property != null)
                        {
                            cs = property.GetCustomAttributes(typeof(CanSortAttribute), true) as CanSortAttribute[];
                            if (cs != null && cs.Length != 0)
                            {
                                if (!cs[0].Allowed(operation)) throw new NotAllowedFilteringException(operation.ToString(), property.Name, type);
                                return;
                            };
                        }
                    }
                    throw new NotAllowedColumnException(property.Name, type);
                }
                if (!cs[0].Allowed(operation)) throw new NotAllowedFilteringException(operation.ToString(), property.Name, type);

            }
            else throw new NotAllowedExpressionException();
        }
        protected void CheckSorting(Expression expression, Type t)
        {
            PropertyInfo property;
            Type type;
            VisitMemeberAccess(expression, t, out type, out property);
            CanSortAttribute[] cs = property.GetCustomAttributes(typeof(CanSortAttribute), true) as CanSortAttribute[];
            if (cs == null || cs.Length == 0)
            {
                MetadataTypeAttribute[] mt = t.GetCustomAttributes(typeof(MetadataTypeAttribute), true) as MetadataTypeAttribute[];
                if (mt != null && mt.Length != 0)
                {
                    property = mt[0].MetadataClassType.GetProperty(property.Name);
                    if (property != null)
                    {
                        cs = property.GetCustomAttributes(typeof(CanSortAttribute), true) as CanSortAttribute[];
                        if (cs != null && cs.Length != 0) return;
                    }
                }
                throw new NotAllowedColumnException(property.Name, type);
            }

        }
        private LambdaExpression GetLambda(Expression e)
        {
            while (e.NodeType == ExpressionType.Quote)
            {
                e = ((UnaryExpression)e).Operand;
            }
            if (e.NodeType == ExpressionType.Constant)
            {
                throw new NotAllowedExpressionException();
                //return ((ConstantExpression)e).Value as LambdaExpression;
            }
            return e as LambdaExpression;
        }
        private void VisitMemeberAccess(Expression e, Type originalType, out Type type, out PropertyInfo property)
        {
            type = null;
            property = null;
            Type actualType = originalType;
            while (e != null && e.NodeType != ExpressionType.Parameter && e != null)
            {

                MemberExpression access = e as MemberExpression;
                if (access == null)
                {
                    if (e.NodeType != ExpressionType.Constant) throw new NotAllowedExpressionException();
                    property = null;
                    e = null;
                    continue;
                }
                type = actualType;
                actualType = e.Type;
                property = access.Member as PropertyInfo;
                if (property == null) throw new NotAllowedExpressionException();
                e = access.Expression;
            }
            if (type == null) throw new NotAllowedExpressionException();

        }
    }
}
