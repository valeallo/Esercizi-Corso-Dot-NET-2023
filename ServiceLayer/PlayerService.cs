using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DbContext;
using DataLayer.Dto;
using SpotifyClone.Controllers;

namespace ServiceLayer
{
    public class PlayerService
    {

        static SpotifyContext DbContext;
        static PlayerService instance;
        public Player player { get; }

        PlayerService()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine(baseDirectory);
            string dataDirectory = Path.Combine(baseDirectory, "data");
            DbContext = new SpotifyContext(dataDirectory);
            player = new Player(this);
            
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
        public List<PlaylistDTO> GetAllPlaylists()
        {
            return DbContext.PlaylistDTOs;
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

        public PlaylistDTO GetPlaylistByName(string albumName)
        {
            return DbContext.PlaylistDTOs.FirstOrDefault(artist => artist.Name.Equals(albumName, StringComparison.OrdinalIgnoreCase));
        }


    }





}

