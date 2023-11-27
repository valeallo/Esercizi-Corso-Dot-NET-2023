using SpotifyClone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpotifyClone
{

    public static class CsvLoader
    {
        internal static void LoadAlbumsFromCsv(string filePath, Listener listener)
        {
            string[] lines = File.ReadAllLines(filePath);
            var songs = lines.Skip(1) 
                .Select(line =>
                {
                    string[] values = line.Split(',');
                    Song song = new Song(values[2], 4.00);
                    Artist artist = listener.AllArtists?.FirstOrDefault(a => a.Name == values[4]) ?? new Artist(values[4], values[4]);
                    song.Artist = artist;
                    listener.AddArtist(artist);
                    
                    if (values[6].Length > 0)
                    {
                        Playlist playlist = listener.Playlists?.FirstOrDefault(a => a.Name == values[6]) ?? new Playlist(values[6]);
                        listener.AddPlaylist(playlist);
                        playlist.AddSong(song);
                    }
                    return new {AlbumTitle = values[3], Artist = artist , Song = song};
                }).ToList();
            var songsGroupedByAlbum = songs.GroupBy(x => x.AlbumTitle);


            foreach (var group in songsGroupedByAlbum)
            {
                string albumTitle = group.Key;
                Song[] songsArray = group.Select(x => x.Song).ToArray();
                Artist albumArtist = group.First().Artist;

                Album album = listener.AllAlbums?.FirstOrDefault(a => a.Name == albumTitle) ?? new Album(albumTitle, songsArray, albumArtist, listener);
            }

           
        }
    }

}
