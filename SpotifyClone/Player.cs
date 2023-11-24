using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone
{
    internal class Player
    {
        public string currentSong {  get; set; }
        IPlaylist playlist { get; set; }

        public Player() 
        {

        
        }


        public void Play() { }
        public void Stop() { }
        public string Next(string[] songs, int currentIndex)
        {
            if (songs == null || songs.Length == 0)
            {
                return "No songs available";
            }

            int nextIndex = (currentIndex + 1) % songs.Length;
            return songs[nextIndex];
        }

        public string Previous(string[] songs, int currentIndex)
        {
            if (songs == null || songs.Length == 0)
            {
                return "No songs available";
            }

            int previousIndex = (currentIndex - 1 + songs.Length) % songs.Length;
            return songs[previousIndex];
        }


    }
}
