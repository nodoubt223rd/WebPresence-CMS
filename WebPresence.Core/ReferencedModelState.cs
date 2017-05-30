using System.Web.Mvc;

namespace WebPresence.Core
{
    internal class ReferencedModelState : ModelState
    {
        public int refCount = 0;
    }
}
