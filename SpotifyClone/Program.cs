using System;

namespace SpotifyClone
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Listener listener = new Listener("ListenerName");
            Artist amyWinehouse = new Artist("Amy Winehouse", "Amy Winehouse");
            Song[] songs = new Song[]
            {
            new Song("Rehab", 3.35),
            new Song("You Know I'm No Good", 4.17),
            new Song("Back to Black", 4.01)
            };

            Album backToBlack = new Album("Back to Black", songs, "2006-10-27", amyWinehouse, listener);
            UIClass ui = new UIClass(listener);
            ui.Start();
        }
    }
}
