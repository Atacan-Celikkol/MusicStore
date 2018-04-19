using MVC_MusicStoreApp.BLL;
using MVC_MusicStoreApp.DAL;
using MVC_MusicStoreApp.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MVC_MusicStoreApp.WebUI.Areas.AdminManager.Controllers
{
    public class AlbumController : Controller
    {
        // GET: AdminManager/Album
        public ActionResult Index()
        {
            return View();
        }

        RepositoryBase<Album> ar = new RepositoryBase<Album>();
        public ActionResult _AlbumList()
        {
            return PartialView(ar.SelectAll());
        }

        [HttpGet]
        public ActionResult AddAlbum()
        {
            ViewBag.Genrelist = new RepositoryBase<Genre>().SelectAll();
            ViewBag.Artistlist= new RepositoryBase<Artist>().SelectAll();
            ViewBag.Process = "AddAlbum";
            return PartialView("_AlbumForm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult AddAlbum(Album item,HttpPostedFileBase file)
        {

            #region Html.BeginForm
            //if (file != null)
            //{
            //    string dosyayolu = string.Format("{0}_{1}", Guid.NewGuid(), file.FileName);
            //    file.SaveAs(Server.MapPath("/Areas/AdminManager/Content/resources/images/" + dosyayolu));
            //}

            //item.AlbumArtUrl = file.FileName; 
            #endregion
            ar.Add(item);
           
            return RedirectToAction("_AlbumList","Album");
        }

        public string AddPicture(int id, string data)
        {
            PictureToSave pictureToSave = new JavaScriptSerializer().Deserialize(data, typeof(PictureToSave)) as PictureToSave;
            string imagePath = "/Areas/AdminManager/Content/resources/images/" + Guid.NewGuid().ToString().Replace("-", "").Substring(0, 5) + ".jpg";
            pictureToSave.SmallPicture.Save(Server.MapPath(imagePath));
            if (id > 0)
            {
                Album album = ar.SelectByID(id);
                    System.IO.File.Delete(Server.MapPath(album.AlbumArtUrl));
            }
            return imagePath;
        }
    }
}