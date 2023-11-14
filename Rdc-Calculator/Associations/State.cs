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
        public State(Country country)
        {
            _country = country;
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
