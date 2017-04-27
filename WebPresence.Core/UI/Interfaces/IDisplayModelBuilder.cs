using System;

namespace WebPresence.Core.UI.Interfaces
{
    public interface IDisplayModelBuilder
    {
        Type DisplayModelType { get; }
        object[] DisplayModelContext { get; }
    }
}
