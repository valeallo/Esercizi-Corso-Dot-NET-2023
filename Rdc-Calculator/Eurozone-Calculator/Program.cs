using System;

namespace Eurozone_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            EuropeanState germany = new EuropeanState("Germany", true);
            germany.DisplayInformation();

            EuropeanState norway = new EuropeanState("Norway", false);
            norway.DisplayInformation();
        }
        
    }

}
