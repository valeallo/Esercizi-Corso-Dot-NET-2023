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
        private int _albumCount;

        public Artist (string name, string Alias) : base (name) 
        { 
            _alias = Alias;
            _albumCount = 0;
            _albums = new Album[0];
        }

        public string Alias { get { return _alias; } }

        public void AddAlbum(Album album)
        {
            if (_albumCount == _albums.Length)
            {
                int newSize = _albums.Length + 1;
                Array.Resize(ref _albums, newSize);
            }

            _albums[_albumCount++] = album;
        }


        public Album[] GetAllAlbums()
        {
            Album[] currentAlbums = new Album[_albumCount];
            Array.Copy(_albums, currentAlbums, _albumCount);
            return currentAlbums;
        }

    }
}
