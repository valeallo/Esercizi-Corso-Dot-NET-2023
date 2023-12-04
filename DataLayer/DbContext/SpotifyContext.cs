using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Dto;
using DataLayer.Models;
using Newtonsoft.Json;


namespace DataLayer.DbContext
{
    public class SpotifyContext : DbContext
    {
        public List<Song> Songs { get; set; }
        public List<Radio> Radios { get; set; }
        public List<Album> Albums { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Listener> listeners { get; set; }
        public List<Playlist> Playlists { get; set; }



        public List<SongDTO> SongDTOs { get; set; }
        public List<AlbumDTO> AlbumDTOs { get; set; }
        public List<ArtistDTO> ArtistDTOs { get; set; }
        public List<RadioDTO> RadioDTOs { get; set; }
        public List<ListenerDTO> ListenerDTOs { get; set; }

        public SpotifyContext(string config) : base(config)
        {

            Artists = LoadFromJsonFile<Artist>(config + "Artists.json");
            Albums = LoadFromJsonFile<Album>(config + "Albums.json");
            Songs = LoadFromJsonFile<Song>(config + "Songs.json");
            Radios = LoadFromJsonFile<Radio>(config + "Radios.json");
            Playlists = LoadFromJsonFile<Playlist>((config + "Playlists.json"));
            listeners = LoadFromJsonFile<Listener>(config + "Users.json");
            MapSongsData();
            CreateDTOs();
        }

        private void MapSongsData()
        {
            foreach (var album in Albums)
            {
                var artist = Artists.FirstOrDefault(a => a.Name == album.ArtistName);
                if (artist != null)
                {
                    if (artist.albums == null)
                        artist.albums = new Album[] { };

                    artist.albums = artist.albums.Concat(new[] { album }).ToArray();
                }
            }

            foreach (var song in Songs)
            {
                var album = Albums.FirstOrDefault(a => a.Name == song.Album);
                var artist = Artists.FirstOrDefault(a => a.Name == song.Artist);

                if (album != null)
                {
                    if (album.TrackList == null)
                        album.TrackList = new MediaTrack[] { };

                    album.TrackList = album.TrackList.Concat(new[] { song }).ToArray();
                }
            }

        }




        private void CreateDTOs()
        {
            SongDTOs = Songs.Select(song => new SongDTO(song)).ToList();
            AlbumDTOs = Albums.Select(album => new AlbumDTO(album)).ToList();
            ArtistDTOs = Artists.Select(artist => new ArtistDTO(artist)).ToList();
            RadioDTOs = Radios.Select(radio => new RadioDTO(radio)).ToList();
            ListenerDTOs = listeners.Select(listener => new ListenerDTO(listener)).ToList();
        }


    }

    
}
