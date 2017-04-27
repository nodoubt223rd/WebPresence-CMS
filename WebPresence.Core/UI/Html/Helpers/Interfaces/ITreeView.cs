using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Mvc.Razor;
using System.Text;
using System.Threading.Tasks;


namespace WebPresence.Core.UI.Html.Helpers.Interfaces
{
    public interface ITreeView
    {
        string TreeView<T>(this HtmlHelper html, string treeId, IEnumerable<T> rootItems);
    }
}
