using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
            Navbar navbar = new Navbar();
            Display display = new Display();
            Controller controller = new Controller();
            Listener listener;




            private UIClass _uiClass;
      

            public MusicPlayer(UIClass uiClass, Listener Listener)
            {
                _uiClass = uiClass;
                listener = Listener;
            }


      
            public void ShowMusicMenu()
            {
                bool inMenu = true;
                int displayStartLine = 10;
                ConsoleColor myColor = ConsoleColor.Magenta;
                string[] currentArrayToDisplay = new string[] {"please select a category" };
                IPlaylist[] currentPlaylist = new IPlaylist[0];
                Artist[] currentArtistsList;
                string selectedMenu = "Album";



                while (inMenu)
                {
                    Console.Clear();
                    navbar.PrintNavbar();
                    controller.PrintCurrentSong();
                    controller.PrintController();
             

                    ClearDisplayArea(displayStartLine, currentArrayToDisplay.Length);
                    Console.ForegroundColor = myColor;
            
                    display.PrintDisplay(currentArrayToDisplay, displayStartLine);

                    char selection = char.ToUpper(Console.ReadKey().KeyChar);


                    Console.WriteLine();
                    if (char.IsDigit(selection))
                    {
                        int number = selection - '0';
               

                        if (selectedMenu == "artists")
                        {
                        
                        }
                        else if ((selectedMenu == "album" || selectedMenu == "playlist" || selectedMenu == "radio") && number <= currentArrayToDisplay.Length)
                        {
                            currentArrayToDisplay = GetSongNames(currentPlaylist[number - 1]);
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
                                currentPlaylist = listener.AllAlbums;
                                currentArrayToDisplay = listener.GetAlbumArray(listener.AllAlbums);
                                break;
                            case 'S':
                                myColor = ConsoleColor.Red;
                                selectedMenu = "artist";
                                currentPlaylist = null;
                                currentArtistsList = listener.AllArtists;
                                currentArrayToDisplay = listener.GetArtistsArray();
                                break;
                            case 'D':
                                myColor = ConsoleColor.Green;
                                selectedMenu = "playlist";
                                currentPlaylist = listener.Playlists;
                                currentArrayToDisplay = listener.GetAlbumArray(listener.Playlists);
                                break;
                            case 'F':
                                myColor = ConsoleColor.Yellow;
                                selectedMenu = "radio";
                                currentPlaylist = listener.Playlists;
                                currentArrayToDisplay = listener.GetAlbumArray(listener.Playlists);
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

            public string[] GetSongNames(IPlaylist playlist)
            {
                if (playlist.Songs == null || playlist.Songs.Length == 0)
                {
                    return new string[0];
                }

                string[] songNames = new string[playlist.Songs.Length];

                for (int i = 0; i < songNames.Length; i++)
                {
                    songNames[i] = playlist.Songs[i].Name; 
                }

                return songNames;
            }

            private void ClearDisplayArea(int startLine, int numberOfLines)
            {
                for (int i = 0; i < numberOfLines; i++)
                {
                    Console.SetCursorPosition(0, startLine + i);
                    Console.Write(new string(' ', Console.WindowWidth));
                }
            }



            class Navbar
            {
                public void PrintNavbar()
                {
                    string space = "    ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("                  (M)Music            (P)Profile            ");
                    Console.WriteLine("                                                         ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(space + "(A)Albums" + space);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(space + "(S)Artists" + space);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(space + "(D)Playlists" + space);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(space + "Radio" + space);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(space + "Search" + space);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("                                                         ");
                }

            }


            class Display
            {

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
                        Console.WriteLine($"      {i + 1}. {array[i]}");
                    }
                }

            }



            class Controller
            {
                public void PrintCurrentSong ()
                {
                    Console.WriteLine("                                                         ");
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor= ConsoleColor.Black;
                    Console.WriteLine("song that its playing now                                          ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("                                                         ");

                }
                public void PrintController ()
                {
                    string space = "    ";
                    string initialspace = "             ";
                    Console.WriteLine("                                                         ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(initialspace + space + "<-" + space);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(space + "Play/Pause" + space);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(space +"->" + space);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(space + "Stop" + space);
                    Console.WriteLine("                                                         ");
                }
            }
           
        }
    }
    
}
