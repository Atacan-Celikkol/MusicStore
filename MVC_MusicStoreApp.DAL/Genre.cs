using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_MusicStoreApp.DAL
{
  public  class Genre: EntityBase
    {
        [Required(ErrorMessage ="Bu Alan Boş Geçilemez")]
        public string Name { get; set; }
        public string Description { get; set; }
        //Mapping
        public virtual List<Album> Albums { get; set; }
    }
}
