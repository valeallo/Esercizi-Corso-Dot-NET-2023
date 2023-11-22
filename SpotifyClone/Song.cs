using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone
{
    internal class Song
    {
        string _name;
        double _duration;
        Album _album;
        Artist _artist;

        public Song(string Name, double Duration) 
        {
            _name = Name;
            _duration = Duration;
        }

        public string Name { get { return _name; } }
        public double Duration { get { return _duration; } }
        public Album Album { get {  return _album; } set { _album = value; } }
        public Artist Artist { get { return _artist; } set { _artist = value; } }
        public string ReleaseDate { get { return _album.ReleaseDate;  } }

}
}
