using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations
{
    internal class Citizen
    {
        Commune _commune;
        public Citizen(Commune commune)
        { 
            _commune = commune;
        }


        public void ChangeCommune (Commune commune)
        {
            _commune.RemoveCitizen(this);
            _commune = commune;
        }
    }
}
