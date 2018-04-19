using MVC_MusicStoreApp.DAL;
using MVC_MusicStoreApp.WebUI.App_Start;
using MVC_MusicStoreApp.WebUI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;


namespace MVC_MusicStoreApp.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            MusicStoreEntities db = new MusicStoreEntities();
            db.Genres.ToList();


            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //Bundle ı elle ekleme işlemi
            //Bu işlem için using e web.optimization ekleniyor ve app_start ekleniyor.
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start()
        {
            //kişi siteye girdiği anda tetiklenen metod
            Session["cart"] = new MyCart();
        }
    }
}
