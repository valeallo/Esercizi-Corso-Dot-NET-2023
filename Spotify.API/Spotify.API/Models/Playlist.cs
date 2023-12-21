using System;
using System.Collections.Generic;

#nullable disable

namespace Spotify.API.Models
{
    public partial class Playlist
    {
        public Playlist()
        {
            PlaylistSongs = new HashSet<PlaylistSong>();
        }

        public int PlaylistId { get; set; }
        public string Title { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; }
    }
}
