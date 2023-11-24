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
            var lines = File.ReadAllLines(filePath);
            var songsGroupedByAlbum = lines.Skip(1) 
                .Select(line =>
                {
                    var values = line.Split(',');
                    var song = new Song(values[2], double.Parse(values[1]));
                    return new { AlbumTitle = values[3], ArtistName = values[4], Song = song };
                })
                .GroupBy(x => x.AlbumTitle);

            foreach (var group in songsGroupedByAlbum)
            {
                var albumTitle = group.Key;
                var artistName = group.First().ArtistName; 
                var songs = group.Select(x => x.Song).ToArray();

                var artist = listener.AllArtists?.FirstOrDefault(a => a.Name == artistName) ?? new Artist(artistName, artistName);
                listener.AddArtist(artist);

                var album = listener.AllAlbums?.FirstOrDefault(a => a.Name == albumTitle) ?? new Album(albumTitle, songs, artist, listener);
                listener.AddAlbum(album);
            }
        }
    }

}
