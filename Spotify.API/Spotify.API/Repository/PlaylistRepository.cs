using Microsoft.Extensions.Logging;
using Spotify.API.Interfaces;
using Spotify.API.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Spotify.API.Repository
{
    public class PlaylistRepository
    {
        private readonly ILogger<PlaylistRepository> _logger;
        private readonly SpotifyContext _context;

        public PlaylistRepository(ILogger<PlaylistRepository> logger, SpotifyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IEnumerable<Playlist>> GetAllAsync()
        {
            return await Task.FromResult(_context.Playlists);
        }

        public async Task<Playlist> GetByIdAsync(int id)
        {
            return await _context.Playlists
                                 .FirstOrDefaultAsync(p => p.PlaylistId == id);
        }

        public async Task<IEnumerable<Playlist>> FindAsync(Expression<Func<Playlist, bool>> predicate)
        {
            return await _context.Playlists
                                 .Where(predicate)
                                 .ToListAsync();
        }

        public async Task AddAsync(Playlist entity)
        {
            await _context.Playlists.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<Playlist> entities)
        {
            await _context.Playlists.AddRangeAsync(entities);
        }

        public void Update(Playlist entity)
        {
            _context.Playlists.Update(entity);
        }

        public void Remove(Playlist entity)
        {
            _context.Playlists.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Playlist> entities)
        {
            _context.Playlists.RemoveRange(entities);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
