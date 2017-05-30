using System.Collections;

namespace WebPresence.Core.Interfaces
{
    public interface IVisualState
    {
        IDictionary Store { set; }
        string ModelName { set; }
    }
}
