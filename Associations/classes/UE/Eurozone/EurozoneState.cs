using Associations.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations.classes.UE.Eurozone
{
    internal class EurozoneState : EUState, IBCE
    {
        public EurozoneState(string Name, EuropeanUnion europeanUnion) : base(Name, europeanUnion)
        {

        }
    }
}
