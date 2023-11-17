using Arrays.classes.UE.Eurozone;
using Arrays.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays.classes.UE
{
    internal class EuropeanUnion
    {
        EUState _EUState;

        public EuropeanUnion()
        {
            new EurozoneState("France", this);
            new EurozoneState("Germany", this);
            new EurozoneState("Greece", this);
            new EurozoneState("Italy", this);
            new EUState("Poland", this);
            new EUState("Romania", this);
            new EUState("Sweden", this);

        }

        public void AddState(EUState state)
        {
            _EUState = state;
        }

        public void RemoveState(EUState state)
        {
            _EUState = null;
        }


        public void ConsultCentralBank(BCE centralBank)
        {

        }

    }
}
