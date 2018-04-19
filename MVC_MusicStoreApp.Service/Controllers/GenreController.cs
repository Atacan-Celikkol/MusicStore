using MVC_MusicStoreApp.BLL;
using MVC_MusicStoreApp.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC_MusicStoreApp.Service.Controllers
{
    public class GenreController : ApiController
    {
        RepositoryBase<Genre> gr = new RepositoryBase<Genre>();
        private List<Genre> GenreList()
        {
         return   gr.SelectAll().Select(x => new Genre{
               ID= x.ID,
               Name= x.Name,
                Description=x.Description
            }).ToList();
        }  
        //Get : api/Genre

          public IHttpActionResult Get()
        {
            var _genreList = GenreList();

            return Json(_genreList);
        }
         //Get: api/Genre/1
        public IHttpActionResult Get(int id)
        {
            var _genreList = gr.SelectByID(id);
            _genreList.Albums = null;

            return Json(_genreList);
        }
         //Post : api/Genre
        public IHttpActionResult Post(Genre item)
        {
            gr.Add(item);

            return Json(GenreList());
        }
        //Put:api/Genre
        public IHttpActionResult Put(Genre item)
        {
            gr.Update(item);
            return Json(GenreList());
        }

        //Delete: api/Delete/1
        public IHttpActionResult Delete(int id)
        {
            gr.Delete(id);

            return Json(GenreList());

        }
    }
}
