using Arrays.classes.UE.Eurozone;
using Arrays.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays.classes.UE
{
    internal class EuropeanUnion
    {
        private List<EUState> _states = new List<EUState>();
        string[] eurozoneCountries = new string[] {
                "Austria", "Belgium", "Cyprus", "Estonia", "Finland",
                "France", "Germany", "Greece", "Ireland", "Italy",
                "Latvia", "Lithuania", "Luxembourg", "Malta", "Netherlands",
                "Portugal", "Slovakia", "Slovenia", "Spain"
            };
        string[] nonEurozoneCountries = new string[] {
                "Bulgaria", "Croatia", "Czech Republic", "Denmark",
                "Hungary", "Poland", "Romania", "Sweden"
            };


        public EuropeanUnion()
        {
  
            foreach (string country in eurozoneCountries)
            {
                _states.Add(new EurozoneState(country, this, 30));
            }

            foreach (string country in nonEurozoneCountries)
            {
                _states.Add(new EUState(country, this, 30));
            }

        }


        public IEnumerable<string> CountryNames
        {
            get
            {
                return _states.Select(state => state.Name);
            }
        }

        public void AddState(EUState state)
        {
            if (!_states.Contains(state))
            {
                _states.Add(state);
            }

        }

        public void RemoveState(EUState state)
        {
            _states.Remove(state);

        }


        public void ConsultCentralBank(BCE centralBank)
        {

        }

    }
}
