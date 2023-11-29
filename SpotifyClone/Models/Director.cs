using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Models
{
    internal class Director : User
    {

        Movie[] _movies; 

        public Director(string name) : base(name)
        {
     
        }


        public void AddMovie(Movie movie)
        {
            if (_movies == null)
            {
                _movies = new Movie[] { movie };
            }
            else
            {
                _movies = _movies.Append(movie).ToArray();
            }
        }


        public Movie[] GetAllMovies()
        {
            Movie[] currentMovies = new Movie[_movies.Length];
            Array.Copy(_movies, currentMovies, _movies.Length);
            return currentMovies;
        }

        public string[] GetAllMoviesNames()
        {
            if (_movies == null || _movies.Length == 0)
            {
                return new string[0];
            }

            string[] array = new string[_movies.Length];
            for (int i = 0; i < _movies.Length; i++)
            {
                array[i] = _movies[i].Name;
            }
            return array;
        }


        public void RemoveMovie(Movie MovieToRemove)
        {
            _movies = _movies.Where(p => p != MovieToRemove).ToArray();
        }

    }
}
