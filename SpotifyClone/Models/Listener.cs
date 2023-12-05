using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using SpotifyClone.Interfaces;
using static SpotifyClone.Models.Listener;

namespace SpotifyClone.Models
{
    internal class Listener : User
    {
        public List<Song> AllSongs { get; private set; }
        public Album[] AllAlbums { get; set; }
        public Artist[] AllArtists { get; set; }
        public RadioCollection RadioCollection { get; set; }
        public MovieCollection MovieCollection { get; set; }



        Playlist[] _playlists;
        public TimeSpan TotalListeningTime { get; private set; }
        public SubscriptionType Subscription { get; set; }


        public string Timezone { get; set; }



        private const int MaxListeningTimeFree = 100;
        private const int MaxListeningTimePremium = 1000;

        public enum SubscriptionType
        {
            Free,
            Premium,
            Gold
        }


        public Listener(string name, SubscriptionType subscription) : base(name)
        {
            Playlist favoritesPlaylist = new Playlist("Favorites");
            _playlists = new Playlist[] { favoritesPlaylist };

            Subscription = subscription;
            TotalListeningTime = TimeSpan.Zero;

            AllSongs = new List<Song>();

            InitializeListenerFromLog();
        }

        public Playlist[] Playlists { get { return _playlists; } }


        public void AddAlbum(Album album)
        {
            if (AllAlbums == null)
            {
                AllAlbums = new Album[] { album };
            }
            else if (!AllAlbums.Contains(album))
            {
                AllAlbums = AllAlbums.Append(album).ToArray();
            }
        }


        public void AddArtist(Artist artist)
        {
            if (AllArtists == null)
            {
                AllArtists = new Artist[] { artist };
            }
            else if (!AllArtists.Contains(artist))
            {
                AllArtists = AllArtists.Append(artist).ToArray();
            }
        }

        public void AddPlaylist(Playlist Playlist)
        {
            if (!_playlists.Contains(Playlist))
            {
                _playlists = _playlists.Append(Playlist).ToArray();
            }

        }

        public void RemovePlaylist(Playlist playlistToRemove)
        {
            _playlists = _playlists.Where(p => p != playlistToRemove).ToArray();
        }

        public string[] GetAlbumArray(IPlaylist[] playlist)
        {
            string[] albumNames = new string[playlist.Length];

            for (int i = 0; i < albumNames.Length; i++)
            {
                albumNames[i] = playlist[i].Name;

            }

            return albumNames;
        }

        public string[] GetArtistsArray()
        {
            string[] artistNames = new string[AllArtists.Length];

            for (int i = 0; i < AllArtists.Length; i++)
            {
                artistNames[i] = AllArtists[i].Name;
            }

            return artistNames;
        }

        public void AddSongToPlaylist(string playlistName, Song song)
        {
            var playlist = _playlists.FirstOrDefault(p => p.Name == playlistName);
            if (playlist != null)
            {
                playlist.AddSong(song);
            }
            else
            {
                Console.WriteLine($"Playlist '{playlistName}' not found.");
            }
        }


        public void UpdateListeningLog(TimeSpan additionalListeningTime)
        {
            string path = Directory.GetCurrentDirectory();
            string logsDirectory = Path.Combine(path, "logs");
            string filePath = Path.Combine(logsDirectory, $"{Name}_timelog.csv"); 

            TotalListeningTime += additionalListeningTime;
            string logEntry = $"{DateTime.UtcNow:yyyy-MM-ddTHH:mm:ss}, {TotalListeningTime:c}";


            File.WriteAllText(filePath, logEntry); 
        }


        public bool CanListen()
        {
            switch (Subscription)
            {
                case SubscriptionType.Free:
                    return TotalListeningTime.TotalHours < MaxListeningTimeFree;
                case SubscriptionType.Premium:
                    return TotalListeningTime.TotalHours < MaxListeningTimePremium;
                case SubscriptionType.Gold:
                    return true;
                default:
                    return false;
            }
        }


        private void InitializeListenerFromLog()
        {
            string path = Directory.GetCurrentDirectory();
            string logsDirectory = Path.Combine(path, "logs");
            string filePath = Path.Combine(logsDirectory, $"{Name}_timelog.csv");

            if (File.Exists(filePath))
            {
                var line = File.ReadAllText(filePath);
                var parts = line.Split(',');
                if (parts.Length >= 2 && TimeSpan.TryParse(parts[1].Trim(), out TimeSpan loggedTime))
                {
                    TotalListeningTime = loggedTime;
                }
            }
        }



        public void AddSong(Song song)
        {
            if (!AllSongs.Contains(song))
            {
                AllSongs.Add(song);
            }
        }

        public void RemoveSong(Song song)
        {
            AllSongs.Remove(song);
        }


        public Song GetSongByName(string name)
        {
            return AllSongs.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }



        public string[] GetDistinctAlbumNames()
        {
            return AllSongs
                .Where(song => song.Album != null)
                .Select(song => song.Album + " - " + song.Artist) 
                .Distinct()
                .ToArray();
  
        }

        public string[] GetDistinctArtistNames()
        {
            return AllSongs
                .Where(song => song.Artist != null)
                .Select(song => song.Artist)
                .Distinct()
                .ToArray();

        }


        public string[] GetAlbumsByArtist(string artistName)
        {
            return AllSongs
                .Where(song => song.Artist != null && song.Artist.Equals(artistName, StringComparison.OrdinalIgnoreCase)) 
                .Select(song => song.Album)
                .Distinct()
                .ToArray(); 
        }
    }
}
