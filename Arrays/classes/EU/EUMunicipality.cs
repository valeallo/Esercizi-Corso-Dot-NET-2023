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
        EUCitizen _citizen;
        City _city;
        private EUCitizen[] _citizens;


        public EUMunicipality(City city, EUProvince province, int citizenCapacity)
        {
            _city = city;
            _province = province;

            _citizens = new EUCitizen[citizenCapacity];
        }

        public void ChangeProvince(EUProvince province, EUParliament EUParliament)
        {
            bool isApproved = _province.BorderRedefinition(EUParliament, this);
            if (isApproved)
            {
                _province = province;
            }
        }

        
        public void AddCitizen(EUCitizen citizen, int index)
        {
            if (index >= 0 && index < _citizens.Length)
            {
                _citizens[index] = citizen;
            }
            else
            {
                Console.WriteLine("Index out of range");
            }
        }


        public void RemoveCitizen(EUID id)
        {
            int index = Array.FindIndex(_citizens, c => c != null && c.ID.Equals(id));
            if (index != -1)
            {
                _citizens[index] = null;
                Console.WriteLine($"Citizen with ID {id.IDNumber} removed.");
            }
            else
            {
                Console.WriteLine("Citizen not found.");
            }
        }



    }
}
