using System.Web.Mvc;

namespace WebPresence.Core.Interfaces
{
    public interface IRebindChildren
    {
        ControllerContext CurrentControllerContext { set; }
        ModelBindingContext CurrentBindingContext { set; }
        IModelBinder CurrentBinder { set; }
    }
}
