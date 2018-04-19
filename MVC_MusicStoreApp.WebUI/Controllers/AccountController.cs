using MVC_MusicStoreApp.BLL;
using MVC_MusicStoreApp.DAL;
using MVC_MusicStoreApp.WebUI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_MusicStoreApp.WebUI.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        RepositoryBase<UserDetail> userRepository = new RepositoryBase<UserDetail>();

        [HttpPost]
        public ActionResult Login(UserDetail _user )
        {
            if (ModelState.IsValid)
            {
                var dbUsers = userRepository.SelectAll();
                var user = dbUsers.Where(x => x.UserName == _user.UserName && x.Password == _user.Password).FirstOrDefault();
                if (user!=null&&user.IsLocked==false)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, true);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index","Home");
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(UserDetail userdetail)
        {
            userdetail.Ticket = Guid.NewGuid().ToString();
            userRepository.Add(userdetail);

         bool cvp=MailHelper.AktivasyonKoduGonder(userdetail.UserName, userdetail.Email, userdetail.Ticket);

            if (cvp)
            {
                return RedirectToAction("Login");
            }

            return View();
        }
        //FormsAuthenticationTicket Araştırınız....
        public ActionResult ActivationUser(string id)
        {
          
           var confirmUser= userRepository.SelectAll().Where(x => x.Ticket == id).FirstOrDefault();
            if (confirmUser!=null)
            {
                confirmUser.IsLocked = false;
            }
            userRepository.Update(confirmUser);

            return RedirectToAction("Login");
        }
    }
}