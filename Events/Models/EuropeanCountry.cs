using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Events.Models.EuropeanCountry;

namespace Events.Models
{
    internal class EuropeanCountry
    {

        int _covidPositives;
        string _name;       
        public delegate void CovidPositivesChangedEventHandler(object sender, CovidPositivesChangedEventArgs e);
        public event CovidPositivesChangedEventHandler OnCovidPositivesChanged;


        public EuropeanCountry(string name) 
        {
            _name = name;
        }

        public string Name { get { return _name; } }

        public int CovidPositives
        {
            get { return _covidPositives; }
            set
            {
                if (_covidPositives != value)
                {
                    _covidPositives = value;
                    OnCovidPositivesChanged?.Invoke(this, new CovidPositivesChangedEventArgs(_covidPositives));
                    Console.WriteLine($"Country {Name}, positives: {_covidPositives} ");
                }
            }
        }


    }






}
