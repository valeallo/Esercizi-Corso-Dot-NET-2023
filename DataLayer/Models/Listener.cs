using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Enums;

namespace DataLayer.Models
{
     class Listener : User
    {

        Playlist[] _playlists;
        internal TimeSpan TotalListeningTime { get; set; }
        internal SubscriptionType Subscription { get; set; }

    }
}
