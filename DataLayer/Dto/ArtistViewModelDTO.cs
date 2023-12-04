using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;

namespace DataLayer.Dto
{

    public class ArtistViewModelDTO
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public List<string> AlbumNames { get; set; } 

        internal ArtistViewModelDTO(Artist artist)
        {
            Name = artist.Name;
            Genre = artist.genre;
            AlbumNames = artist.albums?.Select(album => album.Name).ToList() ?? new List<string>();
        }

        public ArtistViewModelDTO()
        {
            AlbumNames = new List<string>();
        }
    }


}
