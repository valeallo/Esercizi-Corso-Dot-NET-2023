using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataLayer.Models
{
     public abstract class MediaTrack
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int ListenCount { get; set; }
        public string[] Playlists { get; set; }

    }
}
