using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone
{
    abstract class Audiotrack
    {
        string _name;

        public Audiotrack (string Name) 
        {
            _name = Name;        
        }
        public string Name { get { return _name; } }
        public  abstract string TrackDetails { get; }
        
    }
}
