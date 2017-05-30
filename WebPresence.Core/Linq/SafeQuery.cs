using System;
using System.Collections.Generic;
using System.Linq;

namespace WebPresence.Core.Linq
{
    public class SafeQuery<T> : IOrderedQueryable<T>
    {
        protected SafeQueryProvider _provider;
        protected IQueryable<T> _inner;

        public IEnumerator<T> GetEnumerator()
        {
            return _inner.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _inner.GetEnumerator();
        }

        public Type ElementType
        {
            get { return typeof(T); }
        }

        public System.Linq.Expressions.Expression Expression
        {
            get { return _inner.Expression; }
        }

        public IQueryProvider Provider
        {
            get { return _provider; }
        }

        public SafeQuery(IQueryable<T> query)
        {
            _inner = query ?? throw new ArgumentNullException("query");
            _provider = new SafeQueryProvider(_inner.Provider, _inner.Expression, false);
        }

        public SafeQuery(IQueryable<T> query, SafeQueryProvider provider)
        {
            _inner = query ?? throw new ArgumentNullException("query");
            _provider = provider ?? throw new ArgumentNullException("provider");
        }
    }
}
