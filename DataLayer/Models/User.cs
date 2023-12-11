using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Enums;

namespace DataLayer.Models
{
    public class User 
    {
        public string Name { get; set; }
        public string Id { get; set; }

        public string playlists  { get; set; }
        internal TimeSpan TotalListeningTime { get; set; }
        internal SubscriptionType Subscription { get; set; }

    }
}
