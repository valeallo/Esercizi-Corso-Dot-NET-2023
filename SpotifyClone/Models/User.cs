using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyClone
{
    internal abstract class User
    {
        string _id;
        string _name;

        public User(string name)
        {
            _id = Guid.NewGuid().ToString();
            _name = name;
        }




        public string Name { get {return _name; } }
        public string Id { get { return _id; } }
    }
}
