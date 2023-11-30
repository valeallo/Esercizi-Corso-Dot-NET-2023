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
            string path = myProjectDirectory();
            string storageDirectory = Path.Combine(path, "storage", "songs.csv");
            string allSongsJsonPath = Path.Combine(path, "storage", "allSongs.json");
            Listener listener = SetupApplication();
            CsvLoader.LoadAlbumsFromCsv(storageDirectory, listener);
            UserDataManager.SaveToJsonFile(listener.AllSongs, allSongsJsonPath);


            UIClass ui = new UIClass(listener);
            ui.AskForTimeZone();
             UserDataManager.SaveToJsonFile(listener.AllSongs, allSongsJsonPath); ;
        }

        static Listener SetupApplication()
        {
            
            SubscriptionType subscriptionType = SubscriptionType.Free;

            Listener listener = new Listener("ListenerName", subscriptionType);
   


            RadioCollection FavoriteRadios = new RadioCollection("FavoriteRadios", listener);
            Radio Zeta = new Radio("Zeta", FavoriteRadios);
            Radio Radio105 = new Radio("Radio105", FavoriteRadios);

            Director director = new Director("Michael Bay");
            MovieCollection AllMovies = new MovieCollection("Allmovies");
            Movie caricaDei101 = new Movie("la carica dei 101", AllMovies, director);
            Movie armageddon = new Movie ("Armageddon", AllMovies, director);


           
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
