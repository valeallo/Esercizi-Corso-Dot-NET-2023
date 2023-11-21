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
            while (isRunning)
            {
                Console.Clear(); 
                Console.WriteLine("Press 'M' to play music, press 'V' to watch movies, press 'Q' to quit.");

                char input = Console.ReadKey().KeyChar;
                Console.WriteLine(); 

                switch (input)
                {
                    case 'M':
                    case 'm':
                        ShowMusicMenu();
                        isRunning = false;
                        break;
                    case 'V':
                    case 'v':
                        Console.WriteLine("Feature not available.");
                        Console.ReadKey(); 
                        break;
                    case 'Q':
                    case 'q':
                        isRunning = false; 
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        Console.ReadKey(); 
                        break;
                }
            }
        }

        private void ShowMusicMenu()
        {
          
            Console.Clear();
            Console.WriteLine("Music Menu:");
            Console.WriteLine("1. Play a song");
            Console.WriteLine("2. View playlist");
            Console.WriteLine("3. Return to main menu");

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
                    Start();
                    return;
                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    Console.ReadKey(); 
                    break;
            }

             ShowMusicMenu();
        }

    }
}
