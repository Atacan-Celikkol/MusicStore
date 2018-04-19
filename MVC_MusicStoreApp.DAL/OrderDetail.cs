using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_MusicStoreApp.DAL
{
   public class OrderDetail: EntityBase
    {
        public int OrderID { get; set; }
        public int AlbumID { get; set; }
        public decimal Price { get; set; }
        public short Quantity { get; set; }
        public double Discount { get; set; }
        // Mapping
        public virtual Album Album { get; set; }
        public virtual Order Order { get; set; }


    }
}
