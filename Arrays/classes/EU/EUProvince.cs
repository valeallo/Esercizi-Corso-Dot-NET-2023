using Arrays.classes.Default;
using Arrays.interfaces.EU;
using System;
using System.Linq;

namespace Arrays.classes.UE
{
    internal class EUProvince : GeographicalArea, IEUPublicAdministration
    {
        EURegion _region;
        private EUMunicipality[] _municipalities;
        public EUProvince(EURegion region)
        {
            _region = region;
            int municipalityCapacity = 2 * _region.NumberOfProvinces;
            _municipalities = new EUMunicipality[municipalityCapacity];
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
                int index = Array.FindIndex(_municipalities, m => m == null);
                if (index != -1)
                {
                    _municipalities[index] = Municipality;
                    Console.WriteLine("province is added");
                }
                else
                {
                    Console.WriteLine("No available space to add a new municipality");
                }
          
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
                _region.RemoveProvince(EUParliament, this);
                _region = region;
                Console.WriteLine("region is changed");
            }
            else
            {
                Console.WriteLine("not approved by eu");
            }
        }

        //border redefinition remove city
        public bool BorderRedefinition(EUParliament EUParliament, EUMunicipality MunicipalityToRemove)
        {
            bool isApproved = EUParliament.ApproveChanges();
            if (isApproved)
            {
                _municipalities = _municipalities.Where(m => m != MunicipalityToRemove).ToArray();
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
