using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone
{
    internal class Playlist
    {
        string _playlistName;
        Song[] _songs;

        public Playlist (string playlistName)
        {
            _playlistName = playlistName;
            _songs = new Song[0];
        }


        public void AddSong(Song song)
        {
          _songs = _songs.Append(song).ToArray();
        }

        public void RemoveSong(Song songToRemove)
        {
          _songs = _songs.Where(s => s != songToRemove).ToArray();
        }

        public Song[] GetAllSongs()
        {
            Song[] allSongs = new Song[_songs.Length];
            Array.Copy(_songs, allSongs, _songs.Length);
            return allSongs;
        }

        public string Name { get { return _playlistName; } }

    }
}
