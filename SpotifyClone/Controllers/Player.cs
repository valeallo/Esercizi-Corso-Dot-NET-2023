using System;
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
        public Artist[] currentArtistsList {  get; set; }
        public IPlaylist[] currentPlaylistCollection { get; set; }

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


        public void Stop ()
        {
            isPlaying = false;
            currentSong = " ";
            currentlyPlaying = 0;
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




        public void UpdateDisplayForMenuOption(string selectedMenu)
        {
            switch (selectedMenu)
            {
                case "album":
                    currentPlaylistCollection = _listener.AllAlbums;
                    currentArrayToDisplay = _listener.GetAlbumArray(_listener.AllAlbums); ;
                    break;
                case "artist":
                    selectedMenu = "artist";
                    currentPlaylistCollection = null;
                    currentArtistsList = _listener.AllArtists;
                    currentArrayToDisplay = _listener.GetArtistsArray();
                    break;
                case "playlist":
                    currentPlaylistCollection = _listener.Playlists;
                    currentArrayToDisplay = _listener.GetAlbumArray(_listener.Playlists); ;
                    break;
                case "radio":
                    currentPlaylistCollection = null;
                    playlist = _listener.RadioCollection;
                    currentArrayToDisplay = GetSongNames();
                    break;
                case "movies":
                    currentPlaylistCollection = null;
                    playlist = _listener.MovieCollection;
                    currentArrayToDisplay = GetSongNames();
                    break;
            }
        }


        public void UpdateDisplayForMenuOption(string selectedMenu, int num)
        {

            switch (selectedMenu)
            {
                case "album":
                    Artist SelectedArtist = currentArtistsList[num - 1];
                    currentPlaylistCollection = SelectedArtist.GetAllAlbums();
                    currentArrayToDisplay = SelectedArtist.GetAllAlbumsNames(); ;
                    break;
                case "songs":
                    playlist = currentPlaylistCollection[num - 1];
                    currentArrayToDisplay = GetSongNames();
                    break;
            }
           
          
        }

    }
}
