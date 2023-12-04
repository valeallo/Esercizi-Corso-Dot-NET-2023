using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public abstract class PlaylistBase
    {
        public MediaTrack[] TrackList { get; set; }

        public string Name { get; set; }
    }
}
