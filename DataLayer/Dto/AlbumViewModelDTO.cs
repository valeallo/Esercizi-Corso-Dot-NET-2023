using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dto
{
   
        public class AlbumViewModelDTO
        {
            public string Name { get; set; }
            public string Artist { get; set; }
            public List<string> SongNames { get; set; } 

            public AlbumViewModelDTO(Album album)
            {
                Name = album.Name;
                SongNames = album.TrackList?.Select(track => track.Name).ToList() ?? new List<string>();
                Artist = album.ArtistName;    
            }

            public AlbumViewModelDTO()
            {
                SongNames = new List<string>();
            }
        }
    
}
