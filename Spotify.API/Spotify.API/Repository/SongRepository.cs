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
    public class SongRepository : IRepository<Song>
    {
        private readonly ILogger<SongRepository> _logger;
        private readonly SpotifyContext _context;

        public SongRepository(ILogger<SongRepository> logger, SpotifyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IEnumerable<Song>> GetAllAsync()
        {
            return await Task.FromResult(_context.Songs);
        }

        public async Task<Song> GetByIdAsync(int id)
        {
            return await _context.Songs
                         .FirstOrDefaultAsync(s => s.SongId == id);
        }

        public async Task<IEnumerable<Song>> FindAsync(Expression<Func<Song, bool>> predicate)
        {
            return await _context.Songs
                        .Where(predicate)
                        .ToListAsync();
        }

        public async Task AddAsync(Song entity)
        {
            await _context.Songs.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<Song> entities)
        {
            await _context.Songs.AddRangeAsync(entities);
        }

        public void Update(Song entity)
        {
            _context.Songs.Update(entity);
        }

        public void Remove(Song entity)
        {
            _context.Songs.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Song> entities)
        {
            _context.Songs.RemoveRange(entities);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
