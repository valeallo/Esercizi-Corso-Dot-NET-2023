using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using SpotifyClone.Interfaces;
using SpotifyClone.Models;

namespace SpotifyClone
{
    internal class Player
    {
        public string currentSong {  get; set; }
        public IPlaylist playlist { get; set; }

        public int currentlyPlaying = 0;

        public string[] currentArrayToDisplay = new string[] { "please select a category" };
        private Listener _listener;
        public bool isPlaying = false;

        public Player(Listener listener) 
        {
            _listener = listener;
        
        }


        public void PlayPause() 
        {
            isPlaying = !isPlaying;
        }


        public void PlayPause(int num)
        {
            currentSong = currentArrayToDisplay[num - 1];
            currentlyPlaying = num;
            isPlaying = !isPlaying;

        }
        public void Next()
        {
            if (currentlyPlaying >= currentArrayToDisplay.Length)
            {
                currentlyPlaying = 1;
                currentSong = currentArrayToDisplay[currentlyPlaying - 1];
            }
            else
            {
                currentlyPlaying++;
                currentSong = currentArrayToDisplay[currentlyPlaying - 1];
            }

        }

        public void Previous()
        {
            if (currentlyPlaying == 1)
            {
                currentlyPlaying = currentArrayToDisplay.Length;
                currentSong = currentArrayToDisplay[currentlyPlaying - 1];
            }
            else
            {
                currentlyPlaying--;
                currentSong = currentArrayToDisplay[currentlyPlaying - 1];
            }
        }


        public string[] GetSongNames()
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
