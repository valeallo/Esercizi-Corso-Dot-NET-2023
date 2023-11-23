using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone
{

    internal class UIClass
    {
        public void Start()
        {
            bool isRunning = true;
            MusicPlayer musicPlayer = new MusicPlayer(this);
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

        public class MusicPlayer
        {
            private UIClass _uiClass;
            string[] backToBlackSongs = {
                    "Rehab",
                    "You Know I'm No Good",
                    "Me & Mr Jones",
                    "Just Friends",
                    "Back to Black", };

            public MusicPlayer(UIClass uiClass)
            {
                _uiClass = uiClass;
            }

            public void ShowMusicMenu()
            {
                bool inMenu = true;
                while (inMenu)
                {
                    Console.Clear();
                    this.Navbar();
                    this.Display(backToBlackSongs);

                    char selection = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    switch (selection)
                    {
                        case '1':
                            Console.WriteLine("You pressed 1");
                            break;
                        case '2':
                            Console.WriteLine("You pressed 2");
                            break;
                        case '3':
                            inMenu = false;
                            break;
                        default:
                            Console.WriteLine("Invalid selection. Please try again.");
                            Console.ReadKey();
                            break;
                    }
                }
            }

            public void Navbar() 
            {
                Console.WriteLine("               (M)Music            (P)Profile            ");
                Console.WriteLine("                                                         ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("    Artists   ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("    Albums    ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("   Playlists  ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("    Radio     ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("    Search    ");
                Console.ForegroundColor= ConsoleColor.White;
                Console.WriteLine("                                                         ");
            }


            public void Display(string[] array)
            {

                    if (array == null || array.Length == 0)
                    {
                        Console.WriteLine("No items to display.");
                        return;
                    }

                    for (int i = 0; i < array.Length; i++)
                    {
                        string space = "     ";
                        Console.WriteLine($"{space}{i + 1}. {array[i]}");
                    }
            }


            public void PlayerScreen ()
            {
            
            
            
            }
        }
    }
    
}
