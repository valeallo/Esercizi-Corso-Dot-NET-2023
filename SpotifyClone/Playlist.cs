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

        public void AddSong (Song song)
        {
            int index = Array.FindIndex(_songs, s => s == null);
            try
            {
                _songs[index] = song;
                Console.WriteLine("song is added");

            }
            catch
            {
                Console.WriteLine("adding song failed");
            }
        }


        public void RemoveSong (Song song)
        {
           
            try
            {
                _songs = _songs.Where(i => i != song).ToArray();

            }
            catch
            {
                Console.WriteLine("removing song failed");
            }
        }



    }
}
