using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Models
{
    abstract class Audiotrack
    {
        string _name;
        Guid _id;
        int _listenCount;

        public Audiotrack(string Name)
        {
            _id = Guid.NewGuid();
            _name = Name;
            _listenCount = 0;
        }
        public string Name { get { return _name; } }
        public string Id { get { return _id.ToString(); } }
        public abstract string GetTrackDetails();
        public int ListenCount { get { return _listenCount; } set { _listenCount = value; } }

        public void IncrementListenCount()
        {
            _listenCount++;
        }

    }
}
