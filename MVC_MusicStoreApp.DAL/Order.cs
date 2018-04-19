using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_MusicStoreApp.DAL
{
   public class Order: EntityBase
    {
        public string ShipAddress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int UserDetailID { get; set; }
        //Mapping
        public virtual UserDetail UserDetail { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }


    }
}
