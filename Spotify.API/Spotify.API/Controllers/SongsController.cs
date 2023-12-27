using Microsoft.AspNetCore.Mvc;
using Spotify.API.Interfaces;
using Spotify.API.Models;
using Spotify.API.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spotify.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongsController : ControllerBase
    {
        private readonly SongRepository _songRepository;

        public SongsController(SongRepository songRepository)
        {
            _songRepository = songRepository;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Song>>> GetAllSongs()
        {
            return Ok(await _songRepository.GetAllAsync());
        }

        [HttpGet("{id}")]
        //public async Task<ActionResult<Song>> GetSong(int id)
        //{
        //    var song = await _songRepository.GetByIdAsync(id);

        //    if (song == null)
        //    {
        //        return NotFound();
        //    }

        //    return song;
        //}

        // POST: songs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Song>> PostSong(Song song)
        {
            await _songRepository.AddAsync(song);
            await _songRepository.SaveChangesAsync();

            return CreatedAtAction("GetSong", new { id = song.SongId }, song);
        }

        // Other actions for Update (PUT), Delete, etc.
    }
}
