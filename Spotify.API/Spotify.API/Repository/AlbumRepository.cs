using Microsoft.Extensions.Logging;
using Spotify.API.Models;

namespace Spotify.API.Repository
{
    public class AlbumRepository
    {

            private readonly ILogger<UserRepository> _logger;
            private readonly SpotifyContext _context;

            public AlbumRepository(ILogger<UserRepository> logger, SpotifyContext context)
            {
                _logger = logger;
                _context = context;
            }
        }
    }
}
