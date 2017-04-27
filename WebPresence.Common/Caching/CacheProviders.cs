using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebPresence.Common.Config;
using WebPresence.Common.Caching.Interfaces;

namespace WebPresence.Common.Caching
{
    public abstract class CacheProvider<TCache> : ICacheProvider
    {
        public int CacheDuration
        {
            get
            {
                return ConfigSettings.DefaultCacheDuration;
            }
        }

        protected TCache _cache;

        public CacheProvider()
        {
            _cache = InitCache();
        }

        protected abstract TCache InitCache();

        public abstract bool Get<T>(string key, out T value);

        public abstract void Set<T>(string key, T value);

        public abstract void Set<T>(string key, T value, int duration);

        public abstract void Clear(string key);

        public abstract IEnumerable<KeyValuePair<string, object>> GetAll();


    }
}
