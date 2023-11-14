using Associations.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations
{
    internal class Province : GeographicalArea, IAdministrativeEntity
    {
        Region _region;
        Commune _commune;
        public Province(Region region)
        {
            _region = region;
        }

        public void ChangeRegion (Region region)
        {
            _region.RemoveProvince(this);
            _region = region;
        }

        public void AddCommune (Commune commune)
        {
            _commune = commune;
        }

        public void RemoveCommune (Commune commune)
        {
            _commune = null;
        }

    }
}
