using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SpotifyClone
{
    internal class Listener : User
    {
       Playlist[] _playlists;
       public Album[] AllAlbums { get; set; }
       public Artist[] AllArtists { get; set; }
       public RadioCollection RadioCollection { get; set; }

      




        public Listener(string name) : base(name)
        {
            Playlist favoritesPlaylist = new Playlist("Favorites");
            _playlists = new Playlist[] { favoritesPlaylist };
        }

        public Playlist[] Playlists { get { return _playlists; } }


        public void AddAlbum(Album album)
        {
            if (AllAlbums == null)
            {
                AllAlbums = new Album[] { album };
            }
            else if(!AllAlbums.Contains(album))
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
           
             _playlists = _playlists.Append(Playlist).ToArray();
   
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

    }
}
