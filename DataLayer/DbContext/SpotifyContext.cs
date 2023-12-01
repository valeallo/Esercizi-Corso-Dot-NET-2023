using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Models;


namespace DataLayer.DbContext
{
    internal class SpotifyContext : DbContext
    {
        public List<Song> Songs {  get; set; }
        public List<Radio> Radios { get; set; }
        public List<MediaTrack> MediaTracks { get; set; }
        public List<Album> Albums { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Listener> listeners { get; set; }


    }
}
