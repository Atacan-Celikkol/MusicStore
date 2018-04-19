using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MVC_MusicStoreApp.WebUI.App_Start
{
    public  class BundleConfig
    {
        //Bundle classı içerisinde BunduleCollection sınıfına ulaşabilmek için usinglere web.optimization ekleniyor,fakat referanslarda yok ise nuget ile indiriliyor.
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Areas/AdminManager/Content/css").Include(
                "~/Areas/AdminManager/Content/resources/css/reset.css",
                "~/Areas/AdminManager/Content/resources/css/style.css",
                "~/Areas/AdminManager/Content/resources/css/invalid.css"
                ));
            bundles.Add(new ScriptBundle("~/Areas/AdminManager/Content/js").Include(
                "~/Scripts/jquery-1.10.2.min.js",
               "~/Areas/AdminManager/Content/resources/scripts/simpla.jquery.configuration.js",
               "~/Areas/AdminManager/Content/resources/scripts/facebox.js"

                ));
        }
    }
}