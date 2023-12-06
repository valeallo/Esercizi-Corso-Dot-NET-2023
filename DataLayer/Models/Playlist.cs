using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public  class Playlist : PlaylistBase
    {

        public  Song[] Songs { get; set; }

    }
}
