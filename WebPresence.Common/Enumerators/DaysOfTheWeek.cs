using System;

namespace WebPresence.Common.Enumerators
{
    /// ========================================================================
    ///  <summary>Specifies a days of week enumeration.</summary>
    /// ========================================================================
    [Flags]
    public enum DaysOfTheWeek
    {
        /// <summary>No date.</summary>
        None = 0,
        /// <summary>Sunday.</summary>
        Sunday = 1,
        /// <summary>Monday.</summary>
        Monday = 2,
        /// <summary>Tuesdaý.</summary>
        Tuesday = 4,
        /// <summary>Wednesday.</summary>
        Wednesday = 8,
        /// <summary>Thursday.</summary>
        Thursday = 16,
        /// <summary>Friday.</summary>
        Friday = 32,
        /// <summary>Saturday.</summary>
        Saturday = 64
    }
}
