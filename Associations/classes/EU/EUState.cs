using Associations.classes.Default;
using Associations.interfaces;
using Associations.interfaces.UE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations.classes.UE
{
    internal class EUState : State, IEuropeanUnion, IONU
    {
        EuropeanUnion _europeanUnion;

        public EUState(string Name, EuropeanUnion EuropeanUnion) : base(Name)
        {
            _europeanUnion = EuropeanUnion;
        }
    }
}
