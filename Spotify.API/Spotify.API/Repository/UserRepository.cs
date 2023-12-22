using Microsoft.Extensions.Logging;
using Spotify.API.Models;

namespace Spotify.API.Repository
{
    public class UserRepository
    {
        private readonly ILogger<UserRepository> _logger;
        private readonly SpotifyContext _context;

        public UserRepository(ILogger<UserRepository> logger , SpotifyContext context)
        {
            _logger = logger;
            _context = context;
        }
    }
}
