using System;

namespace WebPresence.Core.Interfaces
{
    public interface IDisplayModel : ISafeCreation
    {
        object ExportToModel(Type TargetType, params object[] context);
        void ImportFromModel(object model, params object[] context);
    }
}
