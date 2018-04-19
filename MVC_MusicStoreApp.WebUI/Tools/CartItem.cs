﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_MusicStoreApp.WebUI.Tools
{
    public class CartItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public short Quantity { get; set; }
        public decimal SubTotal { get { return Price* Quantity; } }
    }
}