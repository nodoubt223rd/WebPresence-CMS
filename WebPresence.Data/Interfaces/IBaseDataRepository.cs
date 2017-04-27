using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WebPresence.Data.Interfaces
{
    public interface IBaseDataRepository<T> where T : class
    {
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        T Add(T item);
        bool Update(params T[] items);
        bool Remove(params T[] items);
    }
}
