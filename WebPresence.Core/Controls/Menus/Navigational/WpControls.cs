using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

using WebPresence.Common;
using WebPresence.Presentation.ViewModels.ContentMenu;

namespace WebPresence.Core.Controls.Menus.Navigational
{
	public static class WpControls
	{
		public static MvcHtmlString ContentTreeView(ContentTree contentItems)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append($"<ol class=\"{Constants.AdminCssClasses.cContentTreeClass}\">");

			foreach (var item in contentItems.ContentTreeNodes)
			{
				sb.Append($"<li class=\"{Constants.AdminCssClasses.cFolderItemClass}\">{item.NodeName}");

				if (item.HasChildren())
				{
					sb.Append("<ol>");
					foreach (var childItem in item.ChildNodes)
					{
						sb.Append($"<li class=\"{Constants.AdminCssClasses.cDefaultFileClass}\"</li>");
					}
					sb.Append("</ol></li>");
				}
				else
					sb.Append("</li>");
			}

			sb.Append("</ol>");

			return MvcHtmlString.Create(sb.ToString()); 
		}
	}
}
