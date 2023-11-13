using System;

namespace Eurozone_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            EUState germany = new EUState("Germany", 0.4f);
            germany.DisplayInformation();

            EUState france = new EUState("France", 0.2f);
            france.DisplayInformation();

        }
        
    }

}
