using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.DbContext;
using DataLayer.Dto;
using DataLayer.Repository;
using SpotifyClone.Controllers;
using DataLayer.Models;
using System.Reflection.Metadata.Ecma335;

namespace ServiceLayer
{
    public class PlayerService
    {


        static PlayerService instance;
        public Player player { get; }
        public UserService userService { get;}

        private MediaRepository<Song, SongDTO, SongDTO> songRepository;
        private MediaRepository<Album, AlbumDTO, AlbumDTO> albumRepository;
        private MediaRepository<Artist, ArtistDTO, ArtistDTO> artistRepository;
        private MediaRepository<Playlist, PlaylistDTO, PlaylistDTO> playlistRepository;
        private MediaRepository<Radio, RadioDTO, RadioDTO> radioRepository;

        //TODO replace with user repository
        private MediaRepository<Listener, ListenerDTO, ListenerDTO> listenerRepository;

        PlayerService()
        {

            songRepository = new MediaRepository<Song, SongDTO, SongDTO>();
            albumRepository = new MediaRepository<Album, AlbumDTO, AlbumDTO>();
            artistRepository = new MediaRepository<Artist, ArtistDTO, ArtistDTO>();
            playlistRepository = new MediaRepository<Playlist, PlaylistDTO, PlaylistDTO>();
            radioRepository = new MediaRepository<Radio, RadioDTO, RadioDTO>();


            //TODO replace with user repository
            listenerRepository = new MediaRepository<Listener, ListenerDTO, ListenerDTO>();


            userService = new UserService(this); 
            player = new Player(this, userService);
            
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
            return songRepository.GetAll();
        }
        public List<RadioDTO> GetAllRadios()
        {
           return radioRepository.GetAll();
        }
        public List<AlbumDTO> GetAllAlbums()
        {
            return albumRepository.GetAll();
        }
        public List<ArtistDTO> GetAllArtists()
        {
            return artistRepository.GetAll();
        }
        public List<ListenerDTO> GetAllListeners()
        {
            return listenerRepository.GetAll();
        }
        public List<PlaylistDTO> GetAllPlaylists()
        {
            return playlistRepository.GetAll();
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
            return artistRepository.GetByName(artistName);
        }
        public AlbumDTO GetAlbumByName(string albumName)
        {
            return albumRepository.GetByName(albumName);
        }

        public PlaylistDTO GetPlaylistByName(string albumName)
        {
            return playlistRepository.GetByName(albumName);
        }


    }





}

