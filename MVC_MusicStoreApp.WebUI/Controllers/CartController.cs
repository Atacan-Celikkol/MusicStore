using MVC_MusicStoreApp.BLL;
using MVC_MusicStoreApp.DAL;
using MVC_MusicStoreApp.WebUI.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_MusicStoreApp.WebUI.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _CartButton()
        {
            return PartialView();
        }
        RepositoryBase<Album> _albumDb = new RepositoryBase<Album>();

        public ActionResult AddToCart(int id)
        {
            var Eklenecek = _albumDb.SelectByID(id);
            CartItem citem = new CartItem();
            citem.ID = Eklenecek.ID;
            citem.Name = Eklenecek.Title;
            citem.Price = Eklenecek.Price;
            citem.Quantity = 1;

            //MyCart cart = Session["cart"] == null ? new MyCart() : Session["cart"] as MyCart;
            MyCart cart = Session["cart"] as MyCart;
            cart.Add(citem);
            Session["cart"] = cart;
            return PartialView("_CartButton");
        }
        public ActionResult _CartItems()
        {
            return View();
        }
    }
}