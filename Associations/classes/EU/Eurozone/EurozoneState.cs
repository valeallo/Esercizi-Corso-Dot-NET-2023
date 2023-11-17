using Associations.interfaces;
using Associations.interfaces.EU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations.classes.UE.Eurozone
{
    internal class EurozoneState : EUState, IEurozone
    {
        public EurozoneState(string Name, EuropeanUnion europeanUnion) : base(Name, europeanUnion)
        {

        }

        public void EuroRegulation()
        {
            Console.WriteLine("I use Euro!");
        }
    }
}
