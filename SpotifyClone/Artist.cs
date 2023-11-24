using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone
{
    internal class Artist : User
    {
        string _alias;
        Album[] _albums;

        public Artist (string name, string Alias) : base (name) 
        {
            _alias = Alias;
        }

        public string Alias { get { return _alias; } }


        public void AddAlbum(Album album)
        {
            if (_albums == null)
            {
                _albums = new Album[] { album };
            }
            else
            {
                _albums = _albums.Append(album).ToArray();
            }
        }


        public Album[] GetAllAlbums()
        {
            Album[] currentAlbums = new Album[_albums.Length];
            Array.Copy(_albums, currentAlbums, _albums.Length);
            return currentAlbums;
        }

        public string[] GetAllAlbumsNames()
        {
             if (_albums == null || _albums.Length == 0)
            {
                return new string[0]; 
            }

            string[] array = new string[_albums.Length];
            for (int i = 0; i < _albums.Length; i++)
            {
                array[i] = _albums[i].Name;
            }
            return array;
        }


        public void RemoveAlbum(Album AlbumToRemove)
        {
            _albums = _albums.Where(p => p != AlbumToRemove).ToArray();
        }


    }
}
