using System;
using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Web.Mvc;

using WebPresence.Presentation.ViewModels.ContentMenu;

namespace WebPresence.Core.Controls.Menu
{
    public class ActionMenuItem<T> : ChildNode where T : Controller
    {
        public Expression<Action<T>> MenuAction { get; set; }

        
    }
}
