using System;

namespace Eurozone_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EUState germany = new EUState("Germany", 0.5f, true, false);
            germany.DisplayInformation();
            Console.WriteLine(germany.IsStateRespectingHumanRights());

            // Create an instance of EurozoneState
            EurozoneState france = new EurozoneState("France", 0.4f, true, false);
            france.DisplayInformation();
            Console.WriteLine(france.DisplayGovernmentBondValue());
            Console.WriteLine(france.CalculateSpread());
            Console.WriteLine(france.IsStateRespectingHumanRights());

            // Create an instance of NonEuropeanState
            NonEuropeanState usa = new NonEuropeanState("USA", 1.0f, true, true);
            usa.DisplayInformation();
            Console.WriteLine(usa.IsStateRespectingHumanRights());

        }
        
    }

}
