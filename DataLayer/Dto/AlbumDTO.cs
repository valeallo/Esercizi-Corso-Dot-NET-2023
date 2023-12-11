using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dto
{
   
        public class AlbumDTO: IMediaObject
        {
            public string Name { get; set; }
  
            public string Artist { get; set; }
            public string Id { get; set; }

            public string Genre { get; set; }
            public List<string> SongNames { get; set; }

            internal AlbumDTO(Album album)
            {
                Name = album.Name;
                SongNames = album.Songs?.Select(track => track.Name).ToList() ?? new List<string>();
                Artist = album.ArtistName; 
                Id = album.Id;
            }

            public AlbumDTO()
            {
                SongNames = new List<string>();
            }
        }
    
}
