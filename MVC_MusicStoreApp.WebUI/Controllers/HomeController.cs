using MVC_MusicStoreApp.BLL;
using MVC_MusicStoreApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_MusicStoreApp.WebUI.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            return View(_albumDb.SelectAll());
        }
        RepositoryBase<Album> _albumDb = new RepositoryBase<Album>();
        RepositoryBase<Genre> _genreDb = new RepositoryBase<Genre>();
        public ActionResult _GenrePartial()
        {
            return PartialView(_genreDb.SelectAll());
        }
    }
}