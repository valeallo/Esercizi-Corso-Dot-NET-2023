using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone
{
    internal class Player
    {
        public string currentSong {  get; set; }
        IPlaylist playlist { get; set; }

        public Player(IPlaylist Playlist) 
        {

            playlist = Playlist;
        
        }


        public void Play() { }
        public void Stop() { }  
        public void Next () { }
        public void Previous () { }
        

    }
}
