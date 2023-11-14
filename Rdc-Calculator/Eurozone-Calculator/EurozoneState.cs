using System;

namespace Eurozone_Calculator
{


    class EurozoneState : EUState, IEuropeanCentralBank
    {
        public EurozoneState(string Name, float GovernmentBond, bool IsONUMember) : base(Name, GovernmentBond, IsONUMember)
        {

        }

        public void DisplayGovernmentBondValue()
        {
            Console.WriteLine($"{Name} Government Bond Value: {GovernmentBond}");
        }

        public void CalculateSpread()
        {
            float bund = 0.3f;

            if (Name == "Germany")
            {
                bund = GovernmentBond;
            }
            Console.WriteLine($"{Name} spread: {GovernmentBond - bund}");
        }


    }
}
