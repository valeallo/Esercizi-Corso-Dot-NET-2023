using Associations.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations
{
    internal class Commune : GeographicalArea, IAdministrativeEntity
    {
        Province _province;
        Citizen _citizen;
        City _city;

        public Commune (Province province, City city)
        {
            _province = province;
            _city = city;
        }

        public void ChangeProvince (Province province)
        {
            _province.RemoveCommune(this);
            _province = province;
        }

        public void AddCitizen (Citizen citizen)
        {
            _citizen = citizen;
        }
        public void RemoveCitizen (Citizen citizen)
        {
            _citizen = null;
        }
       
    }
}
