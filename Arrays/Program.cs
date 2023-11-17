using Arrays.classes.Default;
using Arrays.classes.EU;
using Arrays.classes.UE;
using System;

namespace Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
        
                EuropeanUnion eu = new EuropeanUnion();

               
                foreach (var countryName in eu.CountryNames)
                {
                    Console.WriteLine(countryName + " ");
                }
           

        }
    }
}
