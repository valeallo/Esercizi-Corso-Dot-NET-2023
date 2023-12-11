using SpotifyClone.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Models
{
    abstract class Audiotrack
    {
        string _name;
        string _id;
        int _listenCount;
        List<string> _playlists;

        public Audiotrack(string Name)
        {
            _id = Guid.NewGuid().ToString();
            _name = Name;
            _listenCount = 0;
            _playlists = new List<string>();
        }
        public string Name { get { return _name; } }
        public string Id { get { return _id.ToString(); } }
        public abstract string GetTrackDetails();
        public int ListenCount { get { return _listenCount; } set { _listenCount = value; } }
        public IEnumerable<string> Playlists { get { return _playlists.AsReadOnly(); } }


        public void AddPlaylistToSong(string playlistName)
        {
            if (!_playlists.Contains(playlistName))
            {
                _playlists.Add(playlistName);
            }
        }

        public void IncrementListenCount()
        {
            _listenCount++;
        }



     

    }
}
