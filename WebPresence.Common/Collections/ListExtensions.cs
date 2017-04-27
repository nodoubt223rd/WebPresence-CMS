using System.Collections.Generic;

namespace WebPresence.Common.Collections
{
    public static class ListExtensions
    {
        public static HashSet<T> ToHashSet<T>(this IList<T> list)
        {
            return new HashSet<T>(list);
        }
    }
}
