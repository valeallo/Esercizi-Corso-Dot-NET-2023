using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Models
{
    internal class EuropeanUnion
    {
        private List<EuropeanCountry> memberCountries = new List<EuropeanCountry>();
        public int TotalCovidPositives { get; private set; }


        public void AddCountry(EuropeanCountry country)
        {
            memberCountries.Add(country);
            country.OnCovidPositivesChanged += UpdateTotalCovidPositives;
        }

        public void UpdateTotalCovidPositives(object sender, CovidPositivesChangedEventArgs e)
        {
            TotalCovidPositives = memberCountries.Sum(country => country.CovidPositives);
            Console.WriteLine($"Updated Total Covid Positives in EU: {TotalCovidPositives}");
        }


    }
}
