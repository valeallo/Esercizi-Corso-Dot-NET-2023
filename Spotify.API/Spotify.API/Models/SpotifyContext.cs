using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Spotify.API.Models
{
    public partial class SpotifyContext : DbContext
    {
        public SpotifyContext()
        {
        }

        public SpotifyContext(DbContextOptions<SpotifyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<Playlist> Playlists { get; set; }
        public virtual DbSet<PlaylistSong> PlaylistSongs { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Spotify; User id = sa ; password = Password.123;Trusted_Connection=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Album>(entity =>
            {
                entity.Property(e => e.AlbumId).HasColumnName("AlbumID");

                entity.Property(e => e.ArtistId).HasColumnName("ArtistID");

                entity.Property(e => e.Genre).HasMaxLength(100);

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Artist)
                    .WithMany(p => p.Albums)
                    .HasForeignKey(d => d.ArtistId)
                    .HasConstraintName("FK__Albums__ArtistID__3B75D760");
            });

            modelBuilder.Entity<Artist>(entity =>
            {
                entity.Property(e => e.ArtistId).HasColumnName("ArtistID");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Playlist>(entity =>
            {
                entity.Property(e => e.PlaylistId).HasColumnName("PlaylistID");

                entity.Property(e => e.CreationDate).HasColumnType("date");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Playlists)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Playlists__UserI__412EB0B6");
            });

            modelBuilder.Entity<PlaylistSong>(entity =>
            {
                entity.HasKey(e => new { e.PlaylistId, e.SongId })
                    .HasName("PK__Playlist__D22F5AEFB19BC0D6");

                entity.Property(e => e.PlaylistId).HasColumnName("PlaylistID");

                entity.Property(e => e.SongId).HasColumnName("SongID");

                entity.HasOne(d => d.Playlist)
                    .WithMany(p => p.PlaylistSongs)
                    .HasForeignKey(d => d.PlaylistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlaylistS__Playl__440B1D61");

                entity.HasOne(d => d.Song)
                    .WithMany(p => p.PlaylistSongs)
                    .HasForeignKey(d => d.SongId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlaylistS__SongI__44FF419A");
            });

            modelBuilder.Entity<Song>(entity =>
            {
                entity.Property(e => e.SongId).HasColumnName("SongID");

                entity.Property(e => e.AlbumId).HasColumnName("AlbumID");

                entity.Property(e => e.Title).HasMaxLength(100);

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Songs)
                    .HasForeignKey(d => d.AlbumId)
                    .HasConstraintName("FK__Songs__AlbumID__3E52440B");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.SubscriptionType).HasMaxLength(50);

                entity.Property(e => e.Username).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
