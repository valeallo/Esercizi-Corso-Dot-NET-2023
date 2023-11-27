using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Models
{
    internal class Song : Audiotrack
    {
        TimeSpan _duration;
        Album _album;
        Artist _artist;

        public Song(string Name, double Duration) : base(Name)
        {
            _duration = TimeSpan.FromSeconds(Duration);
        }

        public TimeSpan Duration { get { return _duration; } }
        public Album Album { get { return _album; } set { _album = value; } }
        public Artist Artist { get { return _artist; } set { _artist = value; } }
        //public string ReleaseDate { get { return _album.ReleaseDate; } }

        public override string TrackDetails { get { return Name + "  -  " + _artist.Alias; } }

    }
}
