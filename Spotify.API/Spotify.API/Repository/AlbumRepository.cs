using Microsoft.Extensions.Logging;
using Spotify.API.Interfaces;
using Spotify.API.Models;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Spotify.API.Repository
{
    public class AlbumRepository 
    {
        private readonly ILogger<AlbumRepository> _logger;
        private readonly SpotifyContext _context;

        public AlbumRepository(ILogger<AlbumRepository> logger, SpotifyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IEnumerable<Album>> GetAllAsync()
        {
            return await Task.FromResult(_context.Albums);
        }

        public async Task<Album> GetByIdAsync(int id)
        {
            return await Task.FromResult(_context.Albums.FirstOrDefault(a => a.AlbumId == id));
        }

        public async Task<IEnumerable<Album>> FindAsync(Expression<Func<Album, bool>> predicate)
        {
            return await Task.FromResult(_context.Albums.Where(predicate).ToList());
        }

        public async Task AddAsync(Album entity)
        {
            await _context.Albums.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<Album> entities)
        {
            await _context.Albums.AddRangeAsync(entities);
        }

        public void Update(Album entity)
        {
            _context.Albums.Update(entity);
        }

        public void Remove(Album entity)
        {
            _context.Albums.Remove(entity);
        }

        public void RemoveRange(IEnumerable<Album> entities)
        {
            _context.Albums.RemoveRange(entities);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
