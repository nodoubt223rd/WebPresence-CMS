using System;

namespace WebPresence.Core.UI.Interfaces
{
    public interface IDisplayModel
    {
        object ExportToModel(Type TargetType, params object[] context);
        void ImportFromModel(object model, params object[] context);
    }
}
