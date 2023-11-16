using Associations.classes.Default;
using Associations.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations.classes.UE
{
    internal class EUMunicipality : City
    { 
        //administrative city class  == Comune in italian
        EUProvince _province;
        Citizen _citizen;

        public EUMunicipality(EUProvince province)
        {
            _province = province;
        }

        public void ChangeProvince(EUProvince province, EUParliament EUParliament)
        {
           bool isApproved = _province.BorderRedefinition(EUParliament, this);
            if(isApproved) {
            _province = province;
            }
        }

        public void AddCitizen(Citizen citizen)
        {
            _citizen = citizen;
        }
        public void RemoveCitizen(Citizen citizen)
        {
            _citizen = null;
        }

    }
}
