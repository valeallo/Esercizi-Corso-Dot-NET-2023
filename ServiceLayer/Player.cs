﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DbContext;
using DataLayer.Dto;
using DataLayer.Models;
using ServiceLayer;


namespace SpotifyClone.Controllers
{
    public class Player
    {
        public string currentSong { get; set; }


        public int currentlyPlaying = 0;
        public List<string> currentArrayToDisplay = new List<string> { "please select a category" };


        public ListenerDTO _listener;
        PlayerService _playerService;
        UserService _userService;
        public bool isPlaying = false;
    


        public Player(PlayerService playerService,UserService userservice)
        {
            _playerService = playerService;
            _userService = userservice;
        }


        public void PlayPause()
        {
            isPlaying = !isPlaying;
        }


        public void PlayPause(int num)
        {
            isPlaying = true;
            int songNumber = num - 1;

      
            if (!_userService.CanListen())
            {
                Random rnd = new Random();
                songNumber = rnd.Next(0, currentArrayToDisplay.Count);

            }
            currentlyPlaying = songNumber + 1;
            currentSong = currentArrayToDisplay[songNumber];
            string selectedSongTitle = currentSong.Split(" - ")[0];
            SongDTO current = _playerService.GetAllSongs().FirstOrDefault(song => song.Name == selectedSongTitle);
            //TODO current?.IncrementListenCount();

            if (current is SongDTO song)
            {
                //TODO
               // _listener.UpdateListeningLog(song.Duration);
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
            if (currentlyPlaying >= currentArrayToDisplay.Count)
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
                currentlyPlaying = currentArrayToDisplay.Count;
                PlayPause(currentlyPlaying);
            }
            else
            {
                currentlyPlaying--;
                PlayPause(currentlyPlaying);
            }
        }




 




        public void UpdateDisplayForMenuOption(string selectedMenu)
        {
            switch (selectedMenu)
            {
                case "album":
                    currentArrayToDisplay = _playerService.GetNamesFromDTOs(_playerService.GetAllAlbums());
                    break;
                case "artist":
                    currentArrayToDisplay = _playerService.GetNamesFromDTOs(_playerService.GetAllArtists());
                    break;
                case "playlist":
                    currentArrayToDisplay = _playerService.GetNamesFromDTOs(_playerService.GetAllPlaylists());
                    break;
                case "radio":
                    currentArrayToDisplay = _playerService.GetNamesFromDTOs(_playerService.GetAllRadios());
                    break;
                case "movies":
   
                    //playlist = _listener.MovieCollection;
                    //currentArrayToDisplay = GetSongNames();
                    break;
            }
        }


        public void UpdateDisplayForMenuOption(string selectedMenu, int num)
        {

            switch (selectedMenu)
            {
                case "album":
                    string artist = currentArrayToDisplay[num - 1];
                    currentArrayToDisplay = _playerService.GetArtistByName(artist).AlbumNames;
                    break;
                case "songs": 
                    string album = currentArrayToDisplay[num - 1];
                    currentArrayToDisplay = _playerService.GetAlbumByName(album).SongNames;
                    break;
                case "songs-playlist":
                    string playlist = currentArrayToDisplay[num - 1];
                    currentArrayToDisplay = _playerService.GetPlaylistByName(playlist).SongNames;
                    break;
            }
           
          
        }

    }
}
