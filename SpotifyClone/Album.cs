using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone
{
    internal class Album : IPlaylist
    {
        string _name;
        Song[] _songs;
        string _realeaseDate;
        int _numberOfSongs;
        Artist _artist;
        public Album(string Name, Song[] songs, string ReleaseDate, Artist artist, Listener listener)
        {
            _name = Name;
            _realeaseDate = ReleaseDate;
            _songs = songs;
            _artist = artist;

            //listener added temporarly cause we dont have a db or a file but this data dont belong in the listener 
            listener.AddAlbum(this);
            listener.AddArtist(artist);
            artist.AddAlbum(this);


            foreach (var song in _songs)
            {
                song.Album = this;
                song.Artist = artist;
            }
        }

            public string Name { get { return _name; } }
            public string ArtistName { get { return _artist.Alias; } }
            public string ReleaseDate { get { return _realeaseDate; } }
            public Audiotrack[] Songs { get {  return _songs; } }


            

    }
}

