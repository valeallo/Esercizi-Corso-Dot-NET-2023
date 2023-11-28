﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using SpotifyClone.Interfaces;
using SpotifyClone.Models;

namespace SpotifyClone.Controllers
{
    internal class Player
    {
        public string currentSong { get; set; }
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
            isPlaying = true;
            int songNumber = num - 1;
            if (!_listener.CanListen())
            {
                Random rnd = new Random();
                songNumber = rnd.Next(0, currentArrayToDisplay.Length);

            }
            currentSong = currentArrayToDisplay[songNumber];
            Audiotrack current = playlist.Songs[songNumber];
            currentlyPlaying = songNumber + 1;

            if (current is Song song)
            {
                _listener.UpdateListeningLog(song.Duration);
            }

        }
        public void Next()
        {
            if (currentlyPlaying >= currentArrayToDisplay.Length)
            {
                PlayPause(1);
            }
            else
            {
                currentlyPlaying++;
                PlayPause(currentlyPlaying);
            }

        }

        public void Previous()
        {
            if (currentlyPlaying == 1)
            {
                currentlyPlaying = currentArrayToDisplay.Length;
                PlayPause(currentlyPlaying);
            }
            else
            {
                currentlyPlaying--;
                PlayPause(currentlyPlaying);
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