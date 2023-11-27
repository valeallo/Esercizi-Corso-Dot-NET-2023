using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using SpotifyClone.Interfaces;
using SpotifyClone.Models;

namespace SpotifyClone
{

    internal class UIClass
    {
        MusicPlayer musicPlayer;
        public UIClass(Listener listener) {

            musicPlayer = new MusicPlayer(this, listener);


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
                        Console.WriteLine("Feature not available.");
                        Console.ReadKey();
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
            Player player = new Player();
            Display display;



            private UIClass _uiClass;
      

            public MusicPlayer(UIClass uiClass, Listener Listener)
            {
                _uiClass = uiClass;
                listener = Listener;
                display = new Display(Listener);
            }


      
            public void ShowMusicMenu()
            {
                bool inMenu = true;
                int displayStartLine = 10;
                ConsoleColor myColor = ConsoleColor.Magenta;
                string[] currentArrayToDisplay = new string[] {"please select a category"};
                IPlaylist[] currentPlaylistCollection = new IPlaylist[0];
                Artist[] currentArtistsList = new Artist[0];
                string selectedMenu = "album";
                int currentlyPlaying = 0;
                IPlaylist currentPlaylist = null;
                bool isPlaying = false;



                while (inMenu)
                {
                    Console.Clear();
                    display.PrintNavbar();
                    display.PrintCurrentSong();
                    display.PrintController();
             

                    display.ClearDisplayArea(displayStartLine, currentArrayToDisplay.Length);
                    Console.ForegroundColor = myColor;
            
                    display.PrintDisplay(currentArrayToDisplay, displayStartLine);

                    char selection = char.ToUpper(Console.ReadKey().KeyChar);


                    Console.WriteLine();
                    if (char.IsDigit(selection))
                    {
                        int number = selection - '0';
               
                        if ((selectedMenu == "songs" || selectedMenu == "radio") && number <= currentArrayToDisplay.Length)
                        {
                            currentlyPlaying = number;
                            isPlaying = true;
                            display.currentSong = currentArrayToDisplay[number - 1];
                        }
                        else if (selectedMenu == "artist" && number <= currentArtistsList.Length)
                        {
                           Artist SelectedArtist = currentArtistsList[number - 1];
                            Console.WriteLine(SelectedArtist.Name);
                            selectedMenu = "album";
                            currentPlaylistCollection = SelectedArtist.GetAllAlbums();
                            currentArrayToDisplay = SelectedArtist.GetAllAlbumsNames();

                        }
                        else if ((selectedMenu == "album" || selectedMenu == "playlist") && number <= currentPlaylistCollection.Length)
                        {
                            selectedMenu = "songs";
                            currentArrayToDisplay = player.GetSongNames(currentPlaylistCollection[number - 1]);
                        } else
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
                                currentPlaylistCollection = listener.AllAlbums;
                                currentArrayToDisplay = listener.GetAlbumArray(listener.AllAlbums);
                                break;
                            case 'S':
                                myColor = ConsoleColor.Red;
                                selectedMenu = "artist";
                                currentPlaylistCollection = null;
                                currentArtistsList = listener.AllArtists;
                                currentArrayToDisplay = listener.GetArtistsArray();
                                break;
                            case 'D':
                                myColor = ConsoleColor.Green;
                                selectedMenu = "playlist";
                                currentPlaylistCollection = listener.Playlists;
                                currentArrayToDisplay = listener.GetAlbumArray(listener.Playlists);
                                break;
                            case 'F':
                                myColor = ConsoleColor.Yellow;
                                selectedMenu = "radio";
                                currentPlaylistCollection = null;
                                currentArrayToDisplay = player.GetSongNames(listener.RadioCollection);
                                break;
                            case 'Z':
                                if (currentlyPlaying >= 1) {
                                    if (currentlyPlaying == 1)
                                    {
                                        currentlyPlaying = currentArrayToDisplay.Length;
                                        display.currentSong = currentArrayToDisplay[currentlyPlaying - 1];
                               
                                    }
                                    else
                                    {
                                   
                                        currentlyPlaying--;
                                        display.currentSong = currentArrayToDisplay[currentlyPlaying - 1];
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid selection. Please try again.");
                                    Console.ReadKey();
                                }
                                break;
                            case 'X':
                                isPlaying = player.Stop(isPlaying);
                                display.currentSongColor = isPlaying ? ConsoleColor.Green :  ConsoleColor.Yellow;
                                break;
                            case 'C':
                                if (currentlyPlaying >= 1)
                                {
                                    if (currentlyPlaying >= currentArrayToDisplay.Length)
                                    {
                                        currentlyPlaying = 1;
                                        display.currentSong = currentArrayToDisplay[currentlyPlaying - 1];
                                    }
                                    else 
                                    {
                                        currentlyPlaying++;
                                        display.currentSong = currentArrayToDisplay[currentlyPlaying -1];
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid selection. Please try again.");
                                    Console.ReadKey();
                                }
                                break;
                            case 'V':
                                isPlaying = false;
                                display.currentSong = " ";
                                currentlyPlaying = 0;
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



     




            class Display
            {
                public string currentSong { get; set; }
                public ConsoleColor currentSongColor = ConsoleColor.Green;
                private Listener _listener;

                public Display(Listener listener)
                {
                    _listener = listener;
                }




                public void PrintNavbar()
                {
                    string space = "    ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($"                     (M)Music            (P)Profile              Listening Time: {_listener.TotalListeningTime}\"");
                    Console.WriteLine("                                                         ");
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
                    Console.WriteLine("                                                         ");
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
                    Console.WriteLine("                                                         ");
                    Console.BackgroundColor = currentSongColor;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(currentSong);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("                                                         ");

                }
                public void PrintController()
                {
                    string space = "    ";
                    string initialspace = "             ";
                    Console.WriteLine("                                                         ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(initialspace + space + "(Z)<-" + space);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(space + "(X)Play/Pause" + space);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(space + "->(C)" + space);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(space + "Stop(V)" + space);
                    Console.WriteLine("                                                         ");
                }
            }


           
        }
    }
    
}
