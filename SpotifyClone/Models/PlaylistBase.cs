﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Models
{
    internal abstract class PlaylistBase
    {
        protected Audiotrack[] _tracks;
        string _name;

        protected PlaylistBase(string Name)
        {
            _name = Name; 
        }

        public Audiotrack[] Songs => _tracks.ToArray();

        public string Name {  get { return _name; } }

        public void AddTrack(Audiotrack audiotrack)
        {
            if (_tracks == null)
            {
                _tracks = new Audiotrack[] { audiotrack };
            }
            else if (!_tracks.Contains(audiotrack))
            {
                _tracks = _tracks.Append(audiotrack).ToArray();
            }

        }

        public void RemoveTrack(Audiotrack audiotrack)
        {
            _tracks = _tracks.Where(p => p != audiotrack).ToArray();
        }


    }
}
