using System;

namespace Eurozone_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            EuropeanState germany = new EuropeanState("Germany", 0.4f, true);
            germany.DisplayInformation();

            EuropeanState norway = new EuropeanState("Norway", 0.2f, false);
            norway.DisplayInformation();

            germany.
        }
        
    }

}
