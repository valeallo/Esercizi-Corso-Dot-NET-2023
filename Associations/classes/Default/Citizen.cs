using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Associations.classes.UE;

namespace Associations.classes.Default
{
    internal class Citizen
    {
        EUMunicipality _municipality;
        public Citizen(EUMunicipality municipality)
        {
            _municipality = municipality;
        }


        public void ChangeCommune(EUMunicipality municipality)
        {
            _municipality.RemoveCitizen(this);
            _municipality = municipality;
        }
    }
}
