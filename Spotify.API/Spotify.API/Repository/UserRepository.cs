using Microsoft.Extensions.Logging;
using Spotify.API.Models;
using Spotify.API.Interfaces;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace Spotify.API.Repository
{
    public class UserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        private readonly SpotifyContext _context;

        public UserRepository(ILogger<UserRepository> logger, SpotifyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await Task.FromResult(_context.Users);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await Task.FromResult(_context.Users.FirstOrDefault(u => u.UserId == id));
        }

        public async Task<IEnumerable<User>> FindAsync(Expression<Func<User, bool>> predicate)
        {
            return await Task.FromResult(_context.Users.Where(predicate).ToList());
        }

        public async Task AddAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<User> entities)
        {
            await _context.Users.AddRangeAsync(entities);
        }

        public void Update(User entity)
        {
            _context.Users.Update(entity);
        }

        public void Remove(User entity)
        {
            _context.Users.Remove(entity);
        }

        public void RemoveRange(IEnumerable<User> entities)
        {
            _context.Users.RemoveRange(entities);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
