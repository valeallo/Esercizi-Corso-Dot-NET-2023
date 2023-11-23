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
       IPlaylist[] _playlists;
       public IPlaylist[] AllAlbums { get; set; }
       public Artist[] AllArtists { get; set; }



        public Listener(string name) : base(name)
        {
            Playlist favoritesPlaylist = new Playlist("Favorites");
            _playlists = new Playlist[] { favoritesPlaylist };
        }

        public IPlaylist[] Playlists { get { return _playlists; } }


        public void AddAlbum(IPlaylist album)
        {
            if (AllAlbums == null)
            {
                AllAlbums = new IPlaylist[] { album };
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



    }
}
