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
    public class OrderController : Controller
    {
        // GET: Order
        RepositoryBase<UserDetail> userRepository = new RepositoryBase<UserDetail>();
        RepositoryBase<Order> orderRepository = new RepositoryBase<Order>();
        public ActionResult OrderCheck()
        {
            var sepet = Session["cart"] as MyCart;
            int UserID = userRepository.SelectAll().Where(x => x.UserName == User.Identity.Name).FirstOrDefault().ID;

            Order yeniSiparis = new Order();
            yeniSiparis.UserDetailID = UserID;
            yeniSiparis.ShipAddress = "Kadıköy";
            yeniSiparis.Email = "a@a.com";
            yeniSiparis.Phone = "123456789";
            yeniSiparis.OrderDetails = new List<OrderDetail>();
            foreach (CartItem item in sepet.Sepet)
            {
                OrderDetail yeniSiparisDetayi = new OrderDetail();
                yeniSiparisDetayi.Discount = 0;
                yeniSiparisDetayi.AlbumID = item.ID;
                yeniSiparisDetayi.Price = item.Price;
                yeniSiparisDetayi.Quantity = item.Quantity;

                yeniSiparis.OrderDetails.Add(yeniSiparisDetayi);
            }
            orderRepository.Add(yeniSiparis);
            Session["cart"] = new MyCart();
            return View();
        }
    }
}