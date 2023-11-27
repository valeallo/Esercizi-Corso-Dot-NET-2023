using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyClone.Interfaces;

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
        public bool Stop(bool isPlaying) 
        {
            return !isPlaying;
        }
        public int Next(string[] currentArrayToDisplay, int currentlyPlaying)
        {
            if (currentlyPlaying >= currentArrayToDisplay.Length)
            {
                return 1;
        
            }
            
             return currentlyPlaying++;
              
           

        }

        public int Previous(string[] currentArrayToDisplay, int currentlyPlaying)
        {
            if (currentlyPlaying == 1)
            {
                return currentArrayToDisplay.Length;
            }

            return  currentlyPlaying--;
        }


        public string[] GetSongNames(IPlaylist playlist)
        {
            if (playlist.Songs == null || playlist.Songs.Length == 0)
            {
                return new string[0];
            }

            string[] songNames = new string[playlist.Songs.Length];

            for (int i = 0; i < songNames.Length; i++)
            {
                songNames[i] = playlist.Songs[i].TrackDetails;
            }

            return songNames;
        }

    }
}
