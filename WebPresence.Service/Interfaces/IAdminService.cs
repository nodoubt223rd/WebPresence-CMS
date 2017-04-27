using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebPresence.Presentation.ViewModels.ContentMenu;

namespace WebPresence.Service.Interfaces
{
    public interface IAdminService
    {
        ContentTree GetContentTree();
    }
}
