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
        private int _playlistCount;

        public Listener(string name) : base(name)
        {
                _playlists = new Playlist[1];
                _playlists[0] = new Playlist("Favorites");
                _playlistCount = 1;
        }


        public void AddPlaylist(Playlist Playlist)
        {
            if (_playlistCount == _playlists.Length)
            {
                int newSize = _playlists.Length + 1;
                Array.Resize(ref _playlists, newSize);
            }

            _playlists[_playlistCount++] = Playlist;
        }


        public Playlist[] GetAllPlaylists()
        {
            Playlist[] currentPlaylists = new Playlist[_playlistCount];
            Array.Copy(_playlists, currentPlaylists, _playlistCount);
            return currentPlaylists;
        }

        public void RemovePlaylist(Playlist playlistToRemove)
        {
            _playlists = _playlists.Where(p => p != playlistToRemove).ToArray();
            _playlistCount = _playlists.Length;
        }


    }
}
