using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotifyClone
{
    internal class Listener : User
    {
        Playlist[] _playlists;
        Playlist _favorites;

        public Listener(string name) : base(name)
        {
            _playlists = new Playlist[0];
            _favorites = new Playlist("Favorites");
        }

        public Playlist Favorites { get { return _favorites; } }
        public Playlist[] Playlists { get { return _playlists; } }


        public void AddPlaylist(Playlist Playlist)
        {
           
             _playlists = _playlists.Append(Playlist).ToArray();
   
        }

        public void RemovePlaylist(Playlist playlistToRemove)
        {
            _playlists = _playlists.Where(p => p != playlistToRemove).ToArray();
        }


        




        //public Playlist[] GetAllPlaylists()
        //{
        //    Playlist[] currentPlaylists = new Playlist[_playlists.Length];
        //    Array.Copy(_playlists, currentPlaylists, _playlists.Length);
        //    return currentPlaylists;
        //}

    }
}
