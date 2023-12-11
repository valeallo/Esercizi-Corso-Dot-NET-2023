using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SpotifyClone.Interfaces;

namespace SpotifyClone.Models
{
    internal class Playlist : IPlaylist
    {
        string _playlistName;
        Song[] _songs;
        string _id;

        public Playlist(string playlistName)
        {
            _playlistName = playlistName;
            _songs = new Song[0];
            _id = Guid.NewGuid().ToString();
        }

        public string Name { get { return _playlistName; } }
        public string Id { get { return _id; } }
        public string[] Songs
        {
            get { return _songs.Select(song => song.Id).ToArray(); }
        }

        public void AddSong(Song song)
        {
            song.AddPlaylistToSong(_id);
            if (_songs == null)
            {
                _songs = new Song[] { song };
            }
            else if (!_songs.Contains(song))
            {
                _songs = _songs.Append(song).ToArray();
            }

        }

        public void RemoveSong(Song songToRemove)
        {
            _songs = _songs.Where(s => s != songToRemove).ToArray();
        }


 

    }
}
