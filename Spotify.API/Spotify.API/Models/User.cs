using System;
using System.Collections.Generic;

#nullable disable

namespace Spotify.API.Models
{
    public partial class User
    {
        public User()
        {
            Playlists = new HashSet<Playlist>();
        }

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string SubscriptionType { get; set; }

        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}
