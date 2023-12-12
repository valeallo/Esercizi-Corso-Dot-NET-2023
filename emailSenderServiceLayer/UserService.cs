using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailSenderDataLayer.DbContext;
using EmailSenderDataLayer.Dto;
using EmailSenderDataLayer.Repository;
using EmailSenderDataLayer.Models;
using System.Reflection.Metadata.Ecma335;

namespace EmailSenderServiceLayer
{
    public class UserService
    {


        static UserService instance;

        public UserService userService { get;}


        //TODO replace with user repository


        UserService()
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

        public static UserService GetInstance()
        {
            if (instance is null)
            {
                instance = new UserService();
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

