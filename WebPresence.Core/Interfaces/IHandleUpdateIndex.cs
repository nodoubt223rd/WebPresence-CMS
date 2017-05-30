using System.Web.Mvc;

namespace WebPresence.Core.Interfaces
{
    public interface IHandleUpdateIndex
    {
        int Index { get; set; }
        ModelStateDictionary ModelState { get; set; }
    }
}
