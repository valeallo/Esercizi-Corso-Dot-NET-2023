using Associations.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations
{
    internal class EUState : State, IEuropeanUnion, IONU
    {
        EuropeanUnion _europeanUnion;

        public EUState (string Name, EuropeanUnion EuropeanUnion) : base (Name)
        {
            _europeanUnion = EuropeanUnion;
        }
    }
}
