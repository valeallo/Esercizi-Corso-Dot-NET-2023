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
        public string Album { get; set; }
        public string Artist { get; set; }

    }
}
