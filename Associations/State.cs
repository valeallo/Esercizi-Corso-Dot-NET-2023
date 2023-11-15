using Associations.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations
{
    internal class State : IAdministrativeEntity
    {
        Region _region;
        Country _country;
        string _name;
        public State (string Name)
        {
            //_country = country;
            _name = Name;
        }
        public void AddRegion (Region region)
        {
            _region = region;
        }
        public void RemoveRegion (Region region)
        {
            _region = null;
        }
    }
}
