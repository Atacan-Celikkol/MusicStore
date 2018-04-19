using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_MusicStoreApp.WebUI.App_Start
{
    //Authentication filter araştırılıp Custom şeklinde Admin için oluşlturulacak
    public class BasicAutFilterAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
          
           
        }
        
    }
}