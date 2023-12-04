using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DbContext;
using DataLayer.Dto;

namespace ServiceLayer
{
    internal class PlayerService
    {

        static SpotifyContext DbContext;
        static PlayerService instance;

        PlayerService()
        {
            string path = Directory.GetCurrentDirectory();
            string storage = Path.Combine(path, "storage");
            DbContext = new SpotifyContext(storage);
        }

        public static PlayerService GetInstance()
        {
            if (instance is null)
            {
                instance = new PlayerService();
            }
            return instance;
        }
        public List<SongDTO> GetAllSongs()
        {
            return DbContext.SongDTOs;
        }
        public List<RadioDTO> GetAllRadios()
        {
            return DbContext.RadioDTOs;
        }
        public List<AlbumDTO> GetAllAlbums()
        {
            return DbContext.AlbumDTOs;
        }
        public List<ArtistDTO> GetAllArtists()
        {
            return DbContext.ArtistDTOs;
        }
        public List<ListenerDTO> GetAllListeners()
        {
            return DbContext.ListenerDTOs;
        }

        public List<string> GetNamesFromDTOs<T>(List<T> dtos) where T : class
        {
            var names = new List<string>();
            var nameProperty = typeof(T).GetProperty("Name");

            if (nameProperty != null)
            {
                foreach (var dto in dtos)
                {
                    var name = nameProperty.GetValue(dto)?.ToString();
                    if (name != null)
                    {
                        names.Add(name);
                    }
                }
            }

            return names;
        }

        public ArtistDTO GetArtistByName(string artistName)
        {
            return DbContext.ArtistDTOs.FirstOrDefault(artist => artist.Name.Equals(artistName, StringComparison.OrdinalIgnoreCase));
        }
        public AlbumDTO GetAlbumByName(string albumName)
        {
            return DbContext.AlbumDTOs.FirstOrDefault(album => album.Name.Equals(albumName, StringComparison.OrdinalIgnoreCase));
        }



    }
}
