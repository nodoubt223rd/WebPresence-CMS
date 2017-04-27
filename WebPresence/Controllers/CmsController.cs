using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebPresence.Controllers
{
    public class CmsController : Controller
    {
        // GET: Cms
        public ActionResult Load(string controller, string view)
        {
            return View();
        }
    }
}