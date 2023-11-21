using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone
{
    internal class Album
    {
        string _name;
        Song[] _songs;
        string _realeaseDate;
        int _numberOfSongs;
        public Album(string Name,  int NumberOfSongs, string ReleaseDate) 
        {
            _name = Name;
            _realeaseDate = ReleaseDate;    
            
        }
    }
}
