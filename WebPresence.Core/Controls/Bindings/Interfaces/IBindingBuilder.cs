using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace WebPresence.Core.Controls.Bindings.Interfaces
{
    public interface IBindingBuilder<M> : IBaseBindingBuilder
    {
        IBindingBuilder<N> ToType<N>(Expression<Func<M, N>> expression);
        IBindingBuilder<M> Add(string binding);
        IBindingBuilder<M> AddMethod(string name, string javaScriptCode);
        IBindingBuilder<M> CSS<F>(
            string className,
            Expression<Func<M, F>> expression,
            string format = null,
            params LambdaExpression[] otherExpressions);
        IBindingBuilder<M> Style<F>(
            string stypePropertyName,
            Expression<Func<M, F>> expression,
            string format = null,
            params LambdaExpression[] otherExpressions);
        IBindingBuilder<M> Attr<F>(
            string attrName,
            Expression<Func<M, F>> expression,
            string format = null,
            params LambdaExpression[] otherExpressions);
        IBindingBuilder<M> Event<F>(
            string eventName,
            Expression<Func<M, F>> expression,
            bool bubble = true,
            string format = null,
            params LambdaExpression[] otherExpressions);
        string GetFullName<F>(Expression<Func<M, F>> expression);
        string VerifyFieldsValid<F>(Expression<Func<M, F>> expression, params LambdaExpression[] otherExpressions);
        string VerifyFormValid();
        LambdaExpression L<F>(Expression<Func<M, F>> expression);
        MvcHtmlString Get();
        string ModelPrefix { get; }
        string ModelName { get; }
        string ValidationType { get; }
        void AddServerErrors(string prefix);
        MvcHtmlString HandleServerErrors();
        void SetHelper(HtmlHelper htmlHelper);
        HtmlHelper GetHelper();
        string GetFullBindingName(LambdaExpression expression);
        string GetCompleteBindingName(LambdaExpression expression);
        dynamic BuildExpression(string text);
        IAncestorBindingBuilder<N, M> Parent<N>();
        IAncestorBindingBuilder<N, M> Root<N>();
        IAncestorBindingBuilder<N, M> Parents<N>(int i);
    }
}
