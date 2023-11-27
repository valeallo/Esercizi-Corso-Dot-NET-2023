using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone.Models
{
    internal abstract class User
    {
        int _id;
        string _name;

        public User(string name)
        {
            _id = GenerateId();
            _name = name;
        }


        private static int GenerateId()
        {
            Random random = new Random();
            return random.Next(100000, 1000000);
        }


        public string Name { get { return _name; } }
        public int Id { get { return _id; } }
    }
}
