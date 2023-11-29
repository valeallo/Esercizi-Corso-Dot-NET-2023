using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Models
{
    internal class Movie : Audiotrack
    {
        Director _director;
        public Movie(string name, MovieCollection collection, Director director) : base(name)
        {
            collection.AddMovie(this);
            _director = director;
            _director.AddMovie(this);
        }

        public override string TrackDetails { get { return Name; } }
        public Director Director { get { return _director; } set { _director = value; } }
    }
}
