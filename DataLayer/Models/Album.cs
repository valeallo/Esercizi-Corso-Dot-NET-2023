using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    internal class Album : PlaylistBase
    {
        public string ArtistName { get; set; } 

        public string Genre { get; set; } 
        public string ReleaseDate {  get; set; }
    }
}
