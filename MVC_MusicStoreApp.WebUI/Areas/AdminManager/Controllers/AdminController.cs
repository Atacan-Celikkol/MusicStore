using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_MusicStoreApp.WebUI.Areas.AdminManager.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminManager/Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}