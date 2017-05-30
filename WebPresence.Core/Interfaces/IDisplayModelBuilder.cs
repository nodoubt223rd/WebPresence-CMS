using System;

namespace WebPresence.Core.Interfaces
{
    public interface IDisplayModelBuilder
    {
        Type DisplayModelType { get; }
        object[] DisplayModelContext { get; }
    }
}
