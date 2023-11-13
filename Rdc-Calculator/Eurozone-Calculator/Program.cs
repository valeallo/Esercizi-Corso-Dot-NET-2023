using System;

namespace Eurozone_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            EuState germany = new EuState("Germany", 0.4f, true);
            germany.DisplayInformation();

            EuState norway = new EuState("Norway", 0.2f, false);
            norway.DisplayInformation();

            germany.
        }
        
    }

}
