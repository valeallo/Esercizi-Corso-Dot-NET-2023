using SpotifyClone.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Models
{
    internal class MovieCollection : IPlaylist
    {
        string _name;
        Movie[] _movies;
        public MovieCollection(string name, Listener listener)
        {

            _name = name;
            listener.MovieCollection = this;
        }

        public string Name { get { return _name; } }

        public void AddMovie(Movie movie)
        {
            if (_movies == null)
            {
                _movies = new Movie[] { movie };
            }
            else if (!_movies.Contains(movie))
            {
                _movies = _movies.Append(movie).ToArray();
            }

        }

        public void RemoveMovie(Movie movie)
        {
            _movies = _movies.Where(p => p != movie).ToArray();
        }




        public Audiotrack[] Songs { get { return _movies; } }
    }
}
