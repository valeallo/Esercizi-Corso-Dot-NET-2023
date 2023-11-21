﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone
{
    internal class Tester
    {

        public static void TestSong()
        {
            Console.WriteLine("Testing Song Class...");

            Song song = new Song("Test Song", "3:30");
            Console.WriteLine($"Created song: {song.Name}, Duration: {song.Duration}");
        }


        public static void TestPlaylist()
        {
            // Create a playlist and add some songs
            Playlist playlist = new Playlist("My Playlist");
            Song song1 = new Song("Song 1", "3:45");
            Song song2 = new Song("Song 2", "4:00");
            Song song3 = new Song("Song 3", "2:55");
            playlist.AddSong(song1);
            playlist.AddSong(song2);
            playlist.AddSong(song3);

            // Remove a song
            Console.WriteLine("removing song 1");
            playlist.RemoveSong(song1);

            // Get all songs and print
            Song[] allSongs = playlist.GetAllSongs();
            Console.WriteLine("Songs in the playlist:");
            foreach (var song in allSongs)
            {
                Console.WriteLine(song.Name);
            }
        }



        public static void TestListenerWithPlaylists()
        {
            // Create a listener
            Listener listener = new Listener("Listener Name");

            // Create and add some playlists
            Playlist playlist1 = new Playlist("Rock Hits");
            Playlist playlist2 = new Playlist("Chill Vibes");
            listener.AddPlaylist(playlist1);
            listener.AddPlaylist(playlist2);

            // Adding songs to playlists (optional, demonstrate if needed)
            Song rockSong = new Song("Rock Song", "3:15");
            Song chillSong = new Song("Chill Song", "4:20");
            playlist1.AddSong(rockSong);
            playlist2.AddSong(chillSong);

            // Remove a playlist
            Console.WriteLine("removing playlist Rock Hits");
            listener.RemovePlaylist(playlist1);

            // Get all playlists and print
            Playlist[] allPlaylists = listener.GetAllPlaylists();
            Console.WriteLine("\nPlaylists for the listener:");
            foreach (var playlist in allPlaylists)
            {
                Console.WriteLine(playlist.Name);
                // Optionally, print songs in each playlist
            }
        }



    }
}
