using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dto
{

    public class PlaylistDTO : MediaObject
    {
        public string Name { get; set; }
        public List<string> SongNames { get; set; }

        public PlaylistDTO(Playlist playlist)
        {
            Name = playlist.Name;
            SongNames = playlist.Songs?.Select(track => track.Name).ToList() ?? new List<string>();
        }

        public PlaylistDTO()
        {
            SongNames = new List<string>();
        }
    }

}
