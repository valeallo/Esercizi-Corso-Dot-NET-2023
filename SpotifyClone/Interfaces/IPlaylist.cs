﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyClone.Models;

namespace SpotifyClone.Interfaces
{
    internal interface IPlaylist
    {
        public Audiotrack[] Songs { get; }

        public string Name { get; }

    }
}
