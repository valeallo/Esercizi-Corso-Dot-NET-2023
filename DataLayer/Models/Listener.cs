using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Enums;

namespace DataLayer.Models
{
    internal class Listener : User
    {

        Playlist[] _playlists;
        public TimeSpan TotalListeningTime { get; private set; }
        public SubscriptionType Subscription { get; set; }

    }
}
