using System;
using System.Collections.Generic;

#nullable disable

namespace Spotify.API.Models
{
    public partial class Song
    {
        public Song()
        {
            PlaylistSongs = new HashSet<PlaylistSong>();
        }

        public int SongId { get; set; }
        public string Title { get; set; }
        public TimeSpan? Duration { get; set; }
        public int? AlbumId { get; set; }

        public virtual Album Album { get; set; }
        public virtual ICollection<PlaylistSong> PlaylistSongs { get; set; }
    }
}
