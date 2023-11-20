using Arrays.classes.Default;
using Arrays.classes.EU;
using Arrays.interfaces;
using Arrays.interfaces.EU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays.classes.UE
{
    internal class EUMunicipality : EUCitizenPublicService
    {

        EUProvince _province;
        City _city;
        private EUCitizen[] _citizens;


        public EUMunicipality(City city, EUProvince province)
        {
            _city = city;
            _province = province;
            int citizenCapacity = province.NumberOfCities * 1000;
            _citizens = new EUCitizen[citizenCapacity];
        }

        public void ChangeProvince(EUProvince newProvince, EUParliament EUParliament)
        {
            bool isApproved = _province.BorderRedefinition(EUParliament, this);
            if (isApproved)
            {
                _province.BorderRedefinition(EUParliament, this);
                _province = newProvince;
            }
        }

        
        public void AddCitizen(EUCitizen citizen)
        {
            int index = Array.FindIndex(_citizens, m => m == null);
            if (index >= 0 && index < _citizens.Length)
            {
                _citizens[index] = citizen;
            }
            else
            {
                Console.WriteLine("Index out of range");
            }
        }


        public void RemoveCitizen(EUCitizen citizenToRemove)
        {

            int index = Array.FindIndex(_citizens, p => p == citizenToRemove);


            if (index >= 0)
            {
                _citizens[index] = null;
                Console.WriteLine($"Citizen {citizenToRemove.Name} removed.");
            }
            else
            {
                Console.WriteLine("Citizen not found.");
            }
        }



    }
}
