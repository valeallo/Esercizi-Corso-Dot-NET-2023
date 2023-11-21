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
            Array.Resize(ref _songs, _songs.Length + 1);
            _songs[_songs.Length - 1] = song;
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

    }
}
