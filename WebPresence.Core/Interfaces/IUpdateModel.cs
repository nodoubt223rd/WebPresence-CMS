
namespace WebPresence.Core.Interfaces
{
    public interface IUpdateModel : ISafeCreation
    {
        object UpdateModel(object model, string[] fields);
        void ImportFromModel(object model, object[] fields, string[] fieldNames, object[] args = null);
    }
}
