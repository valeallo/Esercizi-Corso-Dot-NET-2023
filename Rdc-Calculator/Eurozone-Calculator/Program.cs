using System;

namespace Eurozone_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EUState germany = new EUState("Germany", 0.5f, true, false);
            germany.DisplayInformation();
            germany.IsStateRespectingHumanRights();

            // Create an instance of EurozoneState
            EurozoneState france = new EurozoneState("France", 0.4f, true, false);
            france.DisplayInformation();
            france.DisplayGovernmentBondValue();
            france.CalculateSpread();
            france.IsStateRespectingHumanRights();

            // Create an instance of NonEuropeanState
            NonEuropeanState usa = new NonEuropeanState("USA", 1.0f, true, true);
            usa.DisplayInformation();
            usa.IsStateRespectingHumanRights();

        }
        
    }

}
