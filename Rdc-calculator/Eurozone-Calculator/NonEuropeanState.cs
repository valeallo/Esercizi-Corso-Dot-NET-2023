using Eurozone_Calculator.interfaces;
using System;
using System.Xml.Linq;


namespace Eurozone_Calculator
{

    class NonEuropeanState : State, IEuropeanHumanRightsCourt
    {

      

        public NonEuropeanState(string Name, float GovernmentBond, bool IsONUMember, bool HasDeathPenalty) : base(Name, GovernmentBond, IsONUMember, HasDeathPenalty)
        {
    
        }


        public override void DisplayInformation()
        {
            Console.WriteLine($"{Name} : Non EU member");
        }


        public void IsStateRespectingHumanRights()
        {
            if (HasDeathPenalty)
            {
                Console.WriteLine($"{Name} is not respecting human rights and has the death penalty.");
            }
            else if (IsONUMember)
            {
                Console.WriteLine($"{Name} respects human rights and is an ONU member");
            }
            else
            {
                Console.WriteLine($"{Name} respects human rights");
            }
        }
    }
}
