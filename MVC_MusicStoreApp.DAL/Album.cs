using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_MusicStoreApp.DAL
{
   public class Album: EntityBase
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string AlbumArtUrl { get; set; }
        public int GenreID { get; set; }
        public int ArtistID { get; set; }

        //Mapping
        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }
    }
}
