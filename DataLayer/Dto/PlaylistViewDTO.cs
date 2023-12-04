using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dto
{

    public class PlaylistViewDTO
    {
        public string Name { get; set; }
        public List<string> SongNames { get; set; }

        public PlaylistViewDTO(Playlist playlist)
        {
            Name = playlist.Name;
            SongNames = playlist.TrackList?.Select(track => track.Name).ToList() ?? new List<string>();
        }

        public PlaylistViewDTO()
        {
            SongNames = new List<string>();
        }
    }

}
