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


            public string[] GetCurrentArray(int num)
            {
                string[] array;

                if (num == 1)
                {
                    array = GetAlbumArray();

                }
                else if (num == 2)
                {
                    array = GetArtistsArray();
                }
                else if (num == 3)
                {
                    array = GetPlaylistsArray();
                }
                else
                {
                    array = new string[0];
                }
                
                return array;   
            }


            public string[] GetAlbumArray ()
            {
                Album[] albums = listener.AllAlbums;
                string[] albumNames = new string[albums.Length];

                foreach (Album album in albums)
                {
                    albumNames = albumNames.Append(album.Name).ToArray();

                }

                return albumNames;
            }

            public string[] GetArtistsArray()
            {
                Artist[] artists = listener.AllArtists;
                string[] artistNames = new string[artists.Length];

                foreach (Artist artist in artists)
                {
                    artistNames = artistNames.Append(artist.Alias).ToArray();
                }

                return artistNames;
            }


            public string[] GetPlaylistsArray()
            {
                Playlist[] playlists = listener.Playlists;
                string[] playlistsName = new string[playlists.Length];

                foreach (Playlist playlist in playlists)
                {
                    playlistsName = playlistsName.Append(playlist.Name).ToArray();
                }

                return playlistsName;
            }



            private void ClearDisplayArea(int startLine, int numberOfLines)
            {
                for (int i = 0; i < numberOfLines; i++)
                {
                    Console.SetCursorPosition(0, startLine + i);
                    Console.Write(new string(' ', Console.WindowWidth));
                }
            }

            public void ShowMusicMenu()
            {
                bool inMenu = true;
                int displayStartLine = 10;
                string[] currentArrayToDisplay = GetCurrentArray(1);
                ConsoleColor myColor = ConsoleColor.Blue;

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

                    switch (selection)
                    {
                        case 'A':
                            myColor = ConsoleColor.Magenta;
                            currentArrayToDisplay = GetCurrentArray(1);
                            break;
                        case 'S':
                            myColor = ConsoleColor.Red;
                            currentArrayToDisplay = GetCurrentArray(2);
                            break;
                        case 'D':
                            myColor = ConsoleColor.Green;
                            currentArrayToDisplay = GetCurrentArray(3);
                            break;
                        case '4':
                            inMenu = false;
                            break;
                        default:
                            Console.WriteLine("Invalid selection. Please try again.");
                            Console.ReadKey();
                            break;
                    }
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
                    Console.Write(space + "(A)Artists" + space);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(space + "(S)Albums" + space);
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
                        Console.WriteLine("     {0}. {1}", i + 1, array[i]);
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
