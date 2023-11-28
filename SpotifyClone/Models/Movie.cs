using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Models
{
    internal class Movie : Audiotrack
    {
        public Movie(string name, RadioCollection collection) : base(name)
        {
            collection.AddRadio();
        }




        public override string TrackDetails { get { return Name; } }
    }
}
