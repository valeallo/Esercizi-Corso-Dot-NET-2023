using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
     class Album : PlaylistBase
    {
        public string ArtistName { get; set; }

        public  Song[] Songs { get; set; }

        public string Genre { get; set; } 
        public string ReleaseDate {  get; set; }
    }
}
