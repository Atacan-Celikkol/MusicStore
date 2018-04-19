using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_MusicStoreApp.DAL
{
 public class Artist: EntityBase
    {
        public string Name { get; set; }
        public byte Rating { get; set; }
        //Mapping
        public virtual List<Album> Albums { get; set; }
    }
}
