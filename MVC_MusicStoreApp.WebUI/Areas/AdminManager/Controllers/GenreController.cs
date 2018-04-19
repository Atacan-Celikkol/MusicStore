using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_MusicStoreApp.DAL;
using MVC_MusicStoreApp.BLL;

namespace MVC_MusicStoreApp.WebUI.Areas.AdminManager.Controllers
{
    public class GenreController : Controller
    {

        RepositoryBase<Genre> _genreDb = new RepositoryBase<Genre>();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _GenreList()
        {

            return PartialView(_genreDb.SelectAll());
        }
        public ActionResult AddGenre()
        {
            ViewBag.Process = "AddGenre";
            return PartialView("_GenreForm");
        }
        [HttpPost]
        public ActionResult AddGenre(Genre item)
        {
            _genreDb.Add(item);
            return RedirectToAction("_GenreList");
        }
      
        public ActionResult UpdateGenre(int id)
        {
            ViewBag.Process = "UpdateGenre";
            var genre = _genreDb.SelectByID(id);
          
            return PartialView("_GenreForm",genre);
        }
        [HttpPost]
        public ActionResult UpdateGenre(Genre item)
        {
            _genreDb.Update(item);

            return RedirectToAction("_GenreList");
        }
        public ActionResult DeleteGenre(int id)
        {
            _genreDb.Delete(id);
            return RedirectToAction("_GenreList");
        }
    }
}