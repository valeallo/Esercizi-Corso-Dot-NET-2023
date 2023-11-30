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
        private Album _album;
        Artist _artist;

        public Song(string Name, double Duration) : base(Name)
        {
            int minutes = (int)Duration;
            int seconds = (int)((Duration - minutes) * 100);
            int totalSeconds = minutes * 60 + seconds;
            _duration = TimeSpan.FromSeconds(totalSeconds);
        }

        public TimeSpan Duration { get { return _duration; } }
        public string Album {get { return _album?.Name; } }
        public string Artist { get { return _artist?.Name; } }
        //public string ReleaseDate { get { return _album.ReleaseDate; } }

        public override string GetTrackDetails ()
        {
            return Name + "  -  " + _artist.Name + "  -  " + _artist.Genre;
        }


        internal void AddAlbum(Album album)
        {
            _album = album;
        }
        internal void AddArtist(Artist artist)
        {
            _artist = artist;
        }
    }
}
