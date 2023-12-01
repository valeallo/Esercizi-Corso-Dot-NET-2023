using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    internal class Song : MediaTrack
    {

        public TimeSpan Duration { get; set; }
        public Album Album { get; set; }
        public Artist Artist { get; set; }

    }
}
