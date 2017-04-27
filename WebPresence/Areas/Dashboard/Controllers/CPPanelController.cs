using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using WebPresence.Common;
using WebPresence.Core.Controls;
using WebPresence.Presentation.ViewModels.ContentMenu;
using WebPresence.Service;
using WebPresence.Service.Interfaces;

namespace WebPresence.Areas.Dashboard.Controllers
{
    public class CPPanelController : Controller
    {
        private readonly IAdminService adminService = new AdminService();

        // GET: Dashboard/CPPanel
        public ActionResult Index()
        {
            return View(adminService.GetContentTree());
        }
    }
}