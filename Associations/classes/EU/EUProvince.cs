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
  

        //overloading border redefinition chane region
        public void BorderRedefinition(EUParliament EUParliament, EURegion region)
        {
            bool isApproved = EUParliament.ApproveChanges();
            if (isApproved) { 
            _region.RemoveProvince(this);
            _region = region;
                Console.WriteLine("region is changed");
            }
        }


        //border redefinition remove city
        public void BorderRedefinition(EUParliament EUParliament,EUMunicipality Municipality)
        {
            bool isApproved = EUParliament.ApproveChanges();
            if (isApproved)
            {
                _municipality = Municipality;
                Console.WriteLine("city is removed");
            }
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
