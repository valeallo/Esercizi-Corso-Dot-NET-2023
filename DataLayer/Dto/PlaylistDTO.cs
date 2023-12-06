using DataLayer.Interfaces;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dto
{

    public class PlaylistDTO : IMediaObject
    {
        public string Name { get; set; }
        public List<string> SongNames { get; set; }

        public string Id { get; set; }
        internal PlaylistDTO(Playlist playlist)
        {
            Name = playlist.Name;
            SongNames = playlist.Songs?.Select(track => track.Name).ToList() ?? new List<string>();
            Id = playlist.Id;
        }

        public PlaylistDTO()
        {
            SongNames = new List<string>();
        }
    }

}
