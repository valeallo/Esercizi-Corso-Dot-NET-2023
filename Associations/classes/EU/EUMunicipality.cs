using Associations.classes.Default;
using Associations.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations.classes.UE
{
    internal class EUMunicipality : City, IAdministrativeEntity
    {
        EUProvince _province;
        Citizen _citizen;

        public EUMunicipality(EUProvince province)
        {
            _province = province;
        }

        public void ChangeProvince(EUProvince province)
        {
            _province.RemoveMunicipality(this);
            _province = province;
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
