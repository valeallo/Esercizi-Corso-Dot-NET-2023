using Microsoft.Extensions.Logging;
using Spotify.API.Interfaces;
using Spotify.API.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Spotify.API.Repository
{
    public class PlaylistSongRepository 
    {
        private readonly ILogger<PlaylistSongRepository> _logger;
        private readonly SpotifyContext _context;

        public PlaylistSongRepository(ILogger<PlaylistSongRepository> logger, SpotifyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IEnumerable<PlaylistSong>> GetAllAsync()
        {
            return await _context.PlaylistSongs
                                 .Include(ps => ps.Playlist)
                                 .Include(ps => ps.Song)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<PlaylistSong>> GetByIdAsync(int playlistId)
        {
            return await _context.PlaylistSongs
                                 .Where(ps => ps.PlaylistId == playlistId)
                                 .Include(ps => ps.Playlist)
                                 .Include(ps => ps.Song)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<PlaylistSong>> FindAsync(Expression<Func<PlaylistSong, bool>> predicate)
        {
            return await _context.PlaylistSongs
                                 .Where(predicate)
                                 .Include(ps => ps.Playlist)
                                 .Include(ps => ps.Song)
                                 .ToListAsync();
        }

        public async Task AddAsync(PlaylistSong entity)
        {
            await _context.PlaylistSongs.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<PlaylistSong> entities)
        {
            await _context.PlaylistSongs.AddRangeAsync(entities);
        }

        public void Update(PlaylistSong entity)
        {
            _context.PlaylistSongs.Update(entity);
        }

        public void Remove(PlaylistSong entity)
        {
            _context.PlaylistSongs.Remove(entity);
        }

        public void RemoveRange(IEnumerable<PlaylistSong> entities)
        {
            _context.PlaylistSongs.RemoveRange(entities);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
