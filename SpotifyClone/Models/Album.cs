using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SpotifyClone.Interfaces;

namespace SpotifyClone.Models
{
    internal class Album : IPlaylist
    {
        string _name;
        Song[] _songs;
        //string _realeaseDate;
        int _numberOfSongs;
        Artist _artist;
        string _genre;
        public Album(string Name, Song[] songs, Artist artist, Listener listener)
        {
            _name = Name;
            //_realeaseDate = ReleaseDate;
            _songs = songs;
            _artist = artist;
            _genre = artist.Genre;

            //listener added temporarly cause we dont have a db or a file but this data dont belong in the listener 
            listener.AddAlbum(this);
            listener.AddArtist(artist);
            artist.AddAlbum(this);


            foreach (var song in _songs)
            {
                song.AddAlbum(this);
                song.AddArtist(artist);
                listener.AddSong(song);
            }
        }

        public string Name { get { return _name; } }
        public string ArtistName { get { return _artist.Name; } }
        //commented release date to have better match with csv
        //public string ReleaseDate { get { return _realeaseDate; } }
        public Audiotrack[] Songs { get { return _songs; } }

        public string Genre { get { return _genre; } }




    }
}

