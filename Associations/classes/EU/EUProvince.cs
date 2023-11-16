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


        public void WelfareServices()
        {
            Console.WriteLine("using region welfare services");
        }

        public void BorderRedefinition(EUParliament eUParliament) {  }
  

        //overloading border redefinition change region
        public void BorderRedefinition(EUParliament EUParliament, EURegion region)
        {
            bool isApproved = EUParliament.ApproveChanges();
            if (isApproved) { 
            _region.BorderRedefinition(EUParliament, this);
            _region = region;
                Console.WriteLine("region is changed");
            }
        }


        //border redefinition remove city
        public bool BorderRedefinition(EUParliament EUParliament,EUMunicipality Municipality)
        {
            bool isApproved = EUParliament.ApproveChanges();
            if (isApproved)
            {
                _municipality = null;
                Console.WriteLine("city is removed");
                return true;
            }
            return false;
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
