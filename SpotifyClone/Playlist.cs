using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone
{
    internal class Playlist : IPlaylist
    {
        string _playlistName;
        Song[] _songs;

        public Playlist (string playlistName)
        {
            _playlistName = playlistName;
            _songs = new Song[0];
        }

        public string Name { get { return _playlistName; } }
        public Song[] Songs { get { return _songs; } }

        public void AddSong(Song song)
        {
            //nel caso mettere un if (song != null )
          _songs = _songs.Append(song).ToArray();
        }

        public void RemoveSong(Song songToRemove)
        {
          _songs = _songs.Where(s => s != songToRemove).ToArray();
        }



    }
}
