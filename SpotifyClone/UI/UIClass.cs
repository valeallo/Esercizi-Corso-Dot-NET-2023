﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SpotifyClone.Controllers;
using SpotifyClone.Interfaces;
using SpotifyClone.Models;

namespace SpotifyClone
{

    internal class UIClass
    {
        MusicPlayer musicPlayer;
        MoviePlayer moviePlayer;
        Listener _listener;
        public UIClass(Listener listener) {

            musicPlayer = new MusicPlayer(this, listener);
            _listener = listener;
            moviePlayer = new MoviePlayer(this, listener);

        }


        public void AskForTimeZone()
        {
            Console.WriteLine("Please enter a nation code (e.g., 'de', 'it', 'fr', 'en-US'): ");
            string inputTimeZoneId = Console.ReadLine();

            try
            {
                string currentTime = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss", new CultureInfo(inputTimeZoneId));
                Console.WriteLine($"You selected this timezone: {inputTimeZoneId}");
                _listener.Timezone = inputTimeZoneId;
                Start();
            }
            catch (TimeZoneNotFoundException)
            {
                Console.WriteLine($"The entered nation code '{inputTimeZoneId}' was not recognized.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void Start()
        {
            bool isRunning = true;
            char input;



            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("Press 'M' to play music, press 'V' to watch movies, press 'Q' to quit.");

                input = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();


                switch (input)
                {
                    case 'M':
                        musicPlayer.ShowMusicMenu();
                        break;
                    case 'V':
                        moviePlayer.ShowMovieMenu();
                        break;
                    case 'Q':
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        Console.ReadKey();
                        break;
                }





                
            }
        }




        class MusicPlayer
        {

            Listener listener;
            Player player;
            Display display;



            private UIClass _uiClass;
      

            public MusicPlayer(UIClass uiClass, Listener Listener)
            {
                _uiClass = uiClass;
                listener = Listener;
                player = new Player(listener);
                display = new Display(Listener, player);
            }


      
            public void ShowMusicMenu()
            {
                bool inMenu = true;
                int displayStartLine = 14;
                ConsoleColor myColor = ConsoleColor.Magenta;
                string selectedMenu = "album";
                player.UpdateDisplayForMenuOption(selectedMenu);



                while (inMenu)
                {
                    Console.Clear();
                    display.PrintNavbar();
                    display.PrintCurrentSong();
                    display.PrintController();
             

                    display.ClearDisplayArea(displayStartLine, player.currentArrayToDisplay.Length);
                    Console.ForegroundColor = myColor;
            
                    display.PrintDisplay(player.currentArrayToDisplay, displayStartLine);

                    char selection = char.ToUpper(Console.ReadKey().KeyChar);


                    Console.WriteLine();
                    if (char.IsDigit(selection))
                    {
                        int number = selection - '0';
               
                        if ((selectedMenu == "songs" || selectedMenu == "radio") && number <= player.currentArrayToDisplay.Length)
                        {
                            player.PlayPause(number);
                        }
                        else if (selectedMenu == "artist" && number <= player.currentArrayToDisplay.Length)
                        {
                            selectedMenu = "album";
                            player.UpdateDisplayForMenuOption(selectedMenu, number);
                        }
                        else if ((selectedMenu == "album") && number <= player.currentPlaylistCollection.Length)
                        {
                            selectedMenu = "songs";
                            player.UpdateDisplayForMenuOption(selectedMenu, number);
                        }
                        else if ((selectedMenu == "playlist") && number <= player.currentPlaylistCollection.Length)
                        {
                            selectedMenu = "songs-playlist";
                            player.UpdateDisplayForMenuOption(selectedMenu, number);
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection. Please try again.");
                            Console.ReadKey();
                        }

                    }
                    else
                    {

                        switch (selection)
                        {
                            case 'A':
                                myColor = ConsoleColor.Magenta;
                                selectedMenu = "album";
                                player.UpdateDisplayForMenuOption(selectedMenu);
                                break;
                            case 'S':
                                myColor = ConsoleColor.Red;
                                selectedMenu = "artist";
                                player.UpdateDisplayForMenuOption(selectedMenu);
                                break;
                            case 'D':
                                myColor = ConsoleColor.Green;
                                selectedMenu = "playlist";
                                player.UpdateDisplayForMenuOption(selectedMenu);
                                break;
                            case 'F':
                                myColor = ConsoleColor.Yellow;
                                selectedMenu = "radio";
                                player.UpdateDisplayForMenuOption(selectedMenu);
                                break;
                            case 'Z':
                                if (player.currentlyPlaying >= 1) {
                                    player.Previous();
                                }
                                else
                                {
                                    Console.WriteLine("Invalid selection. Please try again.");
                                    Console.ReadKey();
                                }
                                break;
                            case 'X':
                                player.PlayPause();
                                display.currentSongColor = player.isPlaying ? ConsoleColor.Green :  ConsoleColor.Yellow;
                                break;
                            case 'C':
                                if (player.currentlyPlaying >= 1)
                                {
                                    player.Next();
                                }
                                else
                                {
                                    Console.WriteLine("Invalid selection. Please try again.");
                                    Console.ReadKey();
                                }
                                break;
                            case 'V':
                                player.isPlaying = false;
                                player.currentSong = " ";
                                player.currentlyPlaying = 0;
                                break;
                            case 'Q':
                                inMenu = false;
                                break;
                            default:
                                Console.WriteLine("Invalid selection. Please try again.");
                                Console.ReadKey();
                                break;
                        }
                    }
                }
            }
           
        }


        class MoviePlayer 
        {
            Listener listener;
            Player player;
            Display display;
            private UIClass _uiClass;

            public MoviePlayer(UIClass uiClass, Listener Listener)
            {
                _uiClass = uiClass;
                listener = Listener;
                player = new Player(listener);
                display = new Display(Listener, player);
            }


            public void ShowMovieMenu()
            {
                bool inMenu = true;
                int displayStartLine = 14;
                ConsoleColor myColor = ConsoleColor.Magenta;
                string selectedMenu = "movies";
                player.UpdateDisplayForMenuOption(selectedMenu);



                while (inMenu)
                {
                    display.CurrentDateTime();
                    Console.Clear();
                    display.PrintCurrentSong();
                    display.PrintController();


                    display.ClearDisplayArea(displayStartLine, player.currentArrayToDisplay.Length);
                    Console.ForegroundColor = myColor;

                    display.PrintDisplay(player.currentArrayToDisplay, displayStartLine);

                    char selection = char.ToUpper(Console.ReadKey().KeyChar);


                    Console.WriteLine();
                    if (char.IsDigit(selection))
                    {
                        int number = selection - '0';

                        if ((selectedMenu == "movies") && number <= player.currentArrayToDisplay.Length)
                        {

                            player.PlayPause(number);

                        }
                        //else if (selectedMenu == "artist" && number <= currentArtistsList.Length)
                        //{
                        //    Artist SelectedArtist = currentArtistsList[number - 1];
                        //    Console.WriteLine(SelectedArtist.Name);
                        //    selectedMenu = "album";
                        //    currentPlaylistCollection = SelectedArtist.GetAllAlbums();
                        //    player.currentArrayToDisplay = SelectedArtist.GetAllAlbumsNames();

                        //}
                    }
                    else
                    {

                        switch (selection)
                        {
                            //case 'S':
                            //    myColor = ConsoleColor.Red;
                            //    selectedMenu = "artist";
                            //    currentPlaylistCollection = null;
                            //    currentArtistsList = listener.AllArtists;
                            //    player.currentArrayToDisplay = listener.GetArtistsArray();
                            //    break; 
                            case 'Z':
                                if (player.currentlyPlaying >= 1)
                                {
                                    player.Previous();
                                }
                                else
                                {
                                    Console.WriteLine("Invalid selection. Please try again.");
                                    Console.ReadKey();
                                }
                                break;
                            case 'X':
                                player.PlayPause();
                                display.currentSongColor = player.isPlaying ? ConsoleColor.Green : ConsoleColor.Yellow;
                                break;
                            case 'C':
                                if (player.currentlyPlaying >= 1)
                                {
                                    player.Next();
                                }
                                else
                                {
                                    Console.WriteLine("Invalid selection. Please try again.");
                                    Console.ReadKey();
                                }
                                break;
                            case 'V':
                                player.Stop();
                                break;
                            case 'Q':
                                inMenu = false;
                                break;
                            default:
                                Console.WriteLine("Invalid selection. Please try again.");
                                Console.ReadKey();
                                break;
                        }
                    }
                }
            }


        }


        class Display
        {

            public ConsoleColor currentSongColor = ConsoleColor.Green;
            private Listener _listener;
            private Player _player;


            public Display(Listener listener, Player player)
            {
                _listener = listener;
                _player = player;
            }


            public void CurrentDateTime()
            {
                string currentTime = DateTime.Now.ToString("dddd, dd MMMM yyyy", new CultureInfo(_listener.Timezone));
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("           " + currentTime + "       ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }

            public void Divider()
            {
                Console.WriteLine("                                                         ");
            }

            public void PrintNavbar()
            {
                string space = "    ";
                Console.ForegroundColor = ConsoleColor.White;
                Divider();
                CurrentDateTime();
                Divider();
                Console.Write($"                     (M)Music            (P)Profile              ");
                Console.Write($"Listening Time: {_listener.TotalListeningTime}\' ");
                Divider();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(space + "(A)Albums" + space);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(space + "(S)Artists" + space);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(space + "(D)Playlists" + space);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(space + "(F)Radio" + space);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(space + "Search" + space);
                Console.ForegroundColor = ConsoleColor.White;
                Divider();
            }


            public void PrintMovieNavbar()
            {
                string space = "    ";
                Console.ForegroundColor = ConsoleColor.White;
                Divider();
                CurrentDateTime();
                Divider();
                Console.Write($"                     (M)Music            (P)Profile              ");
                Console.Write($"Listening Time: {_listener.TotalListeningTime}\' ");
                Divider();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(space + "(A)Albums" + space);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(space + "(S)Artists" + space);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(space + "(D)Playlists" + space);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(space + "(F)Radio" + space);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(space + "Search" + space);
                Console.ForegroundColor = ConsoleColor.White;
                Divider();
            }
            public void PrintDisplay(string[] array, int startingLine)
            {

                Console.SetCursorPosition(0, startingLine);

                if (array == null || array.Length == 0)
                {
                    Console.WriteLine("No items to display.");
                    return;
                }

                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Length > 0)
                    {
                        Console.WriteLine($"      {i + 1}. {array[i]}");
                    }
                }
            }


            public void ClearDisplayArea(int startLine, int numberOfLines)
            {
                for (int i = 0; i < numberOfLines; i++)
                {
                    if (i > 0)
                    {
                        Console.SetCursorPosition(0, startLine + i);
                    }
                    Console.Write(new string(' ', Console.WindowWidth));
                }
            }
            public void PrintCurrentSong()
            {
                Divider();
                Console.BackgroundColor = currentSongColor;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine(_player.currentSong);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Divider();

            }
            public void PrintController()
            {
                string space = "    ";
                string initialspace = "             ";
                Divider();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write(initialspace + space + "(Z)<-" + space);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(space + "(X)Play/Pause" + space);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(space + "->(C)" + space);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(space + "Stop(V)" + space);
                Divider();
            }




        }
    }
    
}
