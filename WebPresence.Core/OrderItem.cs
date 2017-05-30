using System;

namespace WebPresence.Core
{
    internal class OrderItem<TValue> : IComparable<OrderItem<TValue>>
        where TValue : IComparable
    {
        public int Place { get; set; }
        public TValue Value { get; set; }

        public int CompareTo(OrderItem<TValue> other)
        {
            return ((IComparable)Value).CompareTo(other.Value);
        }
    }
}
