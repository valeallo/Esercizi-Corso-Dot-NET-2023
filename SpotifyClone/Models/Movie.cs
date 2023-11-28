using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Models
{
    internal class Movie : Audiotrack
    {
        public Movie(string name, MovieCollection collection) : base(name)
        {
            collection.AddMovie(this);
        }

        public override string TrackDetails { get { return Name; } }
    }
}
