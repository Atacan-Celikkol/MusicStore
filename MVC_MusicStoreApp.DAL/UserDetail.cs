using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_MusicStoreApp.DAL
{
   public class UserDetail: EntityBase
    {
        public UserDetail()
        {
            IsLocked = true;
        }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsLocked { get; set; }
        public string Ticket { get; set; }
        //Mapping

        public virtual List<Order> Orders { get; set; }

    }
}
