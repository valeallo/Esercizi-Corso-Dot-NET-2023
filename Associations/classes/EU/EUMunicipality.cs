using Associations.classes.Default;
using Associations.classes.EU;
using Associations.interfaces;
using Associations.interfaces.EU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations.classes.UE
{
    internal class EUMunicipality : EUCitizenPublicService
    {

        EUProvince _province;
        EUCitizen _citizen;
        City _city;

        public EUMunicipality(City city, EUProvince province)
        {
            _city = city;
            _province = province;
        }

        public void ChangeProvince(EUProvince province, EUParliament EUParliament)
        {
            bool isApproved = _province.BorderRedefinition(EUParliament, this);
            if (isApproved)
            {
                _province = province;
            }
        }

        public void AddCitizen(EUCitizen citizen)
        {
            _citizen = citizen;
        }
        public void RemoveCitizen(EUCitizen citizen)
        {
            _citizen = null;
        }



    }
}
