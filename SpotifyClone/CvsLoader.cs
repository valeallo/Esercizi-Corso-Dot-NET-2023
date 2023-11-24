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
        internal static List<Album> LoadAlbumsFromCsv(string filePath, Listener listener)
        {
            var albums = new List<Album>();
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines.Skip(1))
            {
                var values = line.Split(',');

                var artist = new Artist(values[4], values[4]);
                var song = new Song(values[2], double.Parse(values[1]));
                var album = new Album(values[3], new Song[] { song }, "UnknownReleaseDate", artist, listener);

                albums.Add(album);
            }

            return albums;
        }
    }
}
