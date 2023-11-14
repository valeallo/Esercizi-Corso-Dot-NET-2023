using Associations.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations
{
    internal class EuropeanUnion
    {
        EUState _EUState;

        public EuropeanUnion() 
        {
            new EUState("France", this);
            new EUState("Germany", this);
            new EUState("Greece", this);
            new EUState("Ireland", this);
            new EUState("Italy", this);
            new EUState("Netherlands", this);
            new EUState("Portugal", this);
            new EUState("Romania", this);
            new EUState("Spain", this);
            new EUState("Sweden", this);

        }

        public void AddState (EUState state)
        {
            _EUState = state;
        }

        public void RemoveState (EUState state)
        {
            _EUState = null;
        }


        public void ConsultCentralBank(BCE centralBank)
        {
 
        }

    }
}
