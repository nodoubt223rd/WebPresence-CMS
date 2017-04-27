using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

using WebPresence.Common.Logging;
using WebPresence.Data.Interfaces;
using WebPresence.Data.Resources;

namespace WebPresence.Data
{
    public class BaseDataRepository<T> : IBaseDataRepository<T> where T : class
    {
        public BaseDataRepository()
        {
            StartUp.StartupOnce();
        }

        public T Add(T item)
        {            
            try
            {
                using (var context = new WebPresenceEntities())
                {
                    context.Entry(item).State = EntityState.Added;

                    context.SaveChanges();

                    return item;
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.Log(string.Format(DataMesages.DataError, ex.Message, typeof(T).FullName), ex, LoggingLevel.Error);

                return null;
            }
        }

        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;

            try
            {
                using (var context = new WebPresenceEntities())
                {
                    IQueryable<T> dbQuery = context.Set<T>();

                    // Apply eager loading.
                    foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                        dbQuery = dbQuery.Include(navigationProperty);

                    list = dbQuery
                        .AsNoTracking()
                        .ToList();
                }

                return list;
            }
            catch (Exception ex)
            {
                LogManager.Instance.Log(string.Format(DataMesages.DataError, ex.Message, typeof(T).FullName), ex, LoggingLevel.Error);
                
                return null;
            }
        }

        public virtual IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;

            try
            {
                using (var context = new WebPresenceEntities())
                {
                    IQueryable<T> dbQuery = context.Set<T>();

                    foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                        dbQuery = dbQuery.Include(navigationProperty);

                    list = dbQuery
                        .AsNoTracking()
                        .Where(where)
                        .ToList();

                    return list;
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.Log(string.Format(DataMesages.DataError, ex.Message, typeof(T).FullName), ex, LoggingLevel.Error);

                return null;
            }
        }

        public virtual T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;

            try
            {
                using (var context = new WebPresenceEntities())
                {
                    IQueryable<T> dbQuery = context.Set<T>();

                    foreach (Expression<Func<T, object>> navigationProperty in navigationProperties)
                        dbQuery = dbQuery.Include<T, object>(navigationProperty);

                    item = dbQuery
                        .AsNoTracking() //Don't track any changes for the selected item
                        .FirstOrDefault(where); //Apply where clause                    
                }

                return item;
            }
            catch (Exception ex)
            {
                LogManager.Instance.Log(string.Format(DataMesages.DataError, ex.Message, typeof(T).FullName), ex, LoggingLevel.Error);

                return null;
            }
        }

        public bool Remove(params T[] items)
        {
            try
            {
                using (var context = new WebPresenceEntities())
                {
                    foreach (T item in items)
                    {
                        context.Entry(item).State = EntityState.Deleted;
                    }

                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.Log(string.Format(DataMesages.DataError, ex.Message, typeof(T).FullName), ex, LoggingLevel.Error);

                return false;
            }
        }

        public bool Update(params T[] items)
        {
            try
            {
                using (var context = new WebPresenceEntities())
                {
                    foreach (T item in items)
                    {
                        context.Entry(item).State = EntityState.Modified;
                    }

                    context.SaveChanges();

                    return true;
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.Log(string.Format(DataMesages.DataError, ex.Message, typeof(T).FullName), ex, LoggingLevel.Error);

                return false;
            }
        }      
    }
}
