﻿using System;
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
        public List<PlaylistDTO> PlaylistDTOs { get; set; }

        public SpotifyContext(string config) : base(config)
        {
            Console.WriteLine("Loading data from JSON files from", config);

            Artists = LoadFromJsonFile<Artist>(Path.Combine(config, "Artists.json"));
            Console.WriteLine($"Loaded {Artists.Count} artists.");

            Albums = LoadFromJsonFile<Album>(Path.Combine(config, "Albums.json"));
            Console.WriteLine($"Loaded {Albums.Count} albums.");

            Songs = LoadFromJsonFile<Song>(Path.Combine(config, "Songs.json"));
            Console.WriteLine($"Loaded {Songs.Count} songs.");

            Radios = LoadFromJsonFile<Radio>(Path.Combine(config, "Radios.json"));
            Console.WriteLine($"Loaded {Radios.Count} radios.");

            Playlists = LoadFromJsonFile<Playlist>(Path.Combine(config, "Playlists.json"));
            Console.WriteLine($"Loaded {Playlists.Count} playlists.");

            listeners = LoadFromJsonFile<Listener>(Path.Combine(config, "Users.json"));
            Console.WriteLine($"Loaded {listeners.Count} listeners.");

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
                    if (album.Songs == null)
                        album.Songs = new Song[] { };

                    album.Songs = album.Songs.Concat(new[] { song }).ToArray();
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
            PlaylistDTOs = Playlists.Select(playlist => new PlaylistDTO(playlist)).ToList();
        }


    }

    
}
