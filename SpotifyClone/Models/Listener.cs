using System;
using System.Collections.Generic;
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
        Playlist[] _playlists;
        public Album[] AllAlbums { get; set; }
        public Artist[] AllArtists { get; set; }
        public RadioCollection RadioCollection { get; set; }
        public TimeSpan TotalListeningTime { get; private set; }
        public SubscriptionType Subscription { get; set; }


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
                artistNames[i] = AllArtists[i].Alias;
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

        public void AddListeningTime(TimeSpan listeningDuration)
        {
                TotalListeningTime += listeningDuration;
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

    }
}
