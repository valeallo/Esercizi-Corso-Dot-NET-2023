using System;
using System.IO;
using SpotifyClone.Controllers;
using SpotifyClone.Models;
using static SpotifyClone.Models.Listener;

namespace SpotifyClone
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Listener listener = SetupApplication();
     

            UIClass ui = new UIClass(listener);
            ui.AskForTimeZone();
        }

        static Listener SetupApplication()
        {
            string path = myProjectDirectory();
            string storageDirectory = Path.Combine(path, "storage", "songs.csv");
            SubscriptionType subscriptionType = SubscriptionType.Free;

            Listener listener = new Listener("ListenerName", subscriptionType);
            CsvLoader.LoadAlbumsFromCsv(storageDirectory, listener);


            RadioCollection FavoriteRadios = new RadioCollection("FavoriteRadios", listener);
            Radio Zeta = new Radio("Zeta", FavoriteRadios);
            Radio Radio105 = new Radio("Radio105", FavoriteRadios);

            Director director = new Director("Michael Bay");
            MovieCollection AllMovies = new MovieCollection("Allmovies");
            Movie caricaDei101 = new Movie("la carica dei 101", AllMovies, director);
            Movie armageddon = new Movie ("Armageddon", AllMovies, director);


            string allSongsJsonPath = Path.Combine(path, "storage", "allSongs.json");


            UserDataManager.SaveToJsonFile(listener.AllSongs, allSongsJsonPath);
            return listener;
        }

        static string myProjectDirectory()
        {
            string path = Directory.GetCurrentDirectory(); 
            DirectoryInfo dInfos = new DirectoryInfo(path);
            string myPath = dInfos.Parent.Parent.Parent.ToString();
            return myPath;

        }
    }
}
