using System;
using SpotifyClone.Models;

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
            listener.AddAlbum(backToBlack);

            Song BackInBlack = new Song("Back in Black", 4.15);
            Artist acdc = new Artist("AC/DC", "AC/DC");
            Song[] acdcSongs = new Song[]
            {
            BackInBlack,
            new Song("You Shook Me All Night Long", 3.30),
            new Song("Hells Bells", 5.12)
            };
            Album backInBlack = new Album("Back in Black", acdcSongs, "1980-07-25", acdc, listener);
            listener.AddAlbum(backInBlack);


            Song dakiti = new Song("Dákiti", 3.25);
            Artist badBunny = new Artist("Bad Bunny", "Bad Bunny");
            Song[] badBunnySongs = new Song[]
            {
            dakiti,
            new Song("La Noche de Anoche", 3.23),
            new Song("Yo Perreo Sola", 2.52)
            };
            Album yhlqmdlg = new Album("YHLQMDLG", badBunnySongs, "2020-02-29", badBunny, listener);
            listener.AddAlbum(yhlqmdlg);

            listener.AddSongToPlaylist("Favorites", BackInBlack);
            listener.AddSongToPlaylist("Favorites", dakiti);

            RadioCollection FavoriteRadios = new RadioCollection("FavoriteRadios", listener);
            Radio Zeta = new Radio("Zeta", FavoriteRadios);
            Radio Radio105 = new Radio("Radio105", FavoriteRadios);


            UIClass ui = new UIClass(listener);
            ui.Start();
        }
    }
}
