using Associations.classes.UE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations.interfaces.UE
{
    internal interface IEUAdministrativeEntity : IAdministrativeEntity
    {

        void BorderRedefinition(EUParliament eUParliament);
        void WelfareServices();

    }
}
