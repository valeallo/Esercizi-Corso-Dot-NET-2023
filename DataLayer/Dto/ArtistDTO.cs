using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;
using DataLayer.Models;

namespace DataLayer.Dto
{

    public class ArtistDTO : IMediaObject
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public List<string> AlbumNames { get; set; } 

        internal ArtistDTO(Artist artist)
        {
            Name = artist.Name;
            Genre = artist.genre;
            AlbumNames = artist.albums?.Select(album => album.Name).ToList() ?? new List<string>();
        }

        public ArtistDTO()
        {
            AlbumNames = new List<string>();
        }
    }


}
