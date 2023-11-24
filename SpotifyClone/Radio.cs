using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone
{
    internal class Radio : Audiotrack
    {
        public Radio (string name, RadioCollection collection) : base (name)
        {
            collection.AddRadio (this);
        }


  

        public override string TrackDetails { get { return Name; } }
    }
}
