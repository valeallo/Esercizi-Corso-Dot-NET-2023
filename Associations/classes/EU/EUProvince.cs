using Associations.classes.Default;
using Associations.interfaces;
using Associations.interfaces.UE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations.classes.UE
{
    internal class EUProvince : GeographicalArea, IEUPublicAdministration
    {
        EURegion _region;
        EUMunicipality _municipality;
        public EUProvince(EURegion region)
        {
            _region = region;
        }

        public void ChangeRegion(EURegion region)
        {
            _region.RemoveProvince(this);
            _region = region;
        }

        public void AddMunicipality(EUMunicipality Municipality)
        {
            _municipality = Municipality;
        }

        public void RemoveMunicipality(EUMunicipality commune)
        {
            _municipality = null;
        }

        public void HealthCareNationalSystem()
        {
            Console.WriteLine("province healthcare");

        }
        public void LawSystem()
        {
            Console.WriteLine("province state");

        }
        public void EducationalSystem()
        {
            Console.WriteLine("province state");

        }


    }
}
