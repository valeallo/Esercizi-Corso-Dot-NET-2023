using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpotifyClone.Interfaces;

namespace SpotifyClone.Models
{
    internal class RadioCollection : IPlaylist
    {
        string _name;
        Radio[] _radios;
        public RadioCollection(string name, Listener listener)
        {

            _name = name;
            listener.RadioCollection = this;
        }

        public string Name { get { return _name; } }

        public void AddRadio(Radio radio)
        {
            if (_radios == null)
            {
                _radios = new Radio[] { radio };
            }
            else if (!_radios.Contains(radio))
            {
                _radios = _radios.Append(radio).ToArray();
            }

        }

        public void RemoveRadio(Radio radio)
        {
            _radios = _radios.Where(p => p != radio).ToArray();
        }

        public Audiotrack[] Songs { get { return _radios; } }
    }
}
