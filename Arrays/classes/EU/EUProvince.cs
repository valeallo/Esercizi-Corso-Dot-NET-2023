using Arrays.classes.Default;
using Arrays.interfaces.EU;
using System;

namespace Arrays.classes.UE
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



        //add city approved
        public void AddCity(EUParliament EUParliament, EUMunicipality Municipality)
        {
            bool isApproved = EUParliament.ApproveChanges();
            if (isApproved)
            {
                _municipality = Municipality;
                Console.WriteLine("province is added");
            }
            else
            {
                Console.WriteLine("not approved by eu");
            }
        }


        public void BorderRedefinition(EUParliament eUParliament) { }


        //overloading border redefinition change region
        public void BorderRedefinition(EUParliament EUParliament, EURegion region)
        {
            bool isApproved = EUParliament.ApproveChanges();
            if (isApproved)
            {
                _region.BorderRedefinition(EUParliament, this);
                _region = region;
                Console.WriteLine("region is changed");
            }
            else
            {
                Console.WriteLine("not approved by eu");
            }
        }

        //border redefinition remove city
        public bool BorderRedefinition(EUParliament EUParliament, EUMunicipality Municipality)
        {
            bool isApproved = EUParliament.ApproveChanges();
            if (isApproved)
            {
                _municipality = null;
                Console.WriteLine("city is removed");
                return true;
            }
            Console.WriteLine("not approved by eu");
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
