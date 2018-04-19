using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_MusicStoreApp.WebUI.Tools
{
    public class MyCart
    {
        //private Dictionary<int, CartItem> _sepet = new Dictionary<int, CartItem>();
        private Dictionary<int, CartItem> _sepet;
        public MyCart()
        {
            _sepet = new Dictionary<int, CartItem>();
        }
        public List<CartItem> Sepet
        {
            get
            {
                return _sepet.Values.ToList();
            }
        }
        public void Add(CartItem item)
        {
            if (_sepet.ContainsKey(item.ID))
            {
                _sepet[item.ID].Quantity += item.Quantity;
                return;
            }
            _sepet.Add(item.ID, item);
        }
        public decimal TotalPrice { get { return _sepet.Sum(x => x.Value.SubTotal); } }
    }
}