using System;
using System.Xml.Linq;


namespace Eurozone_Calculator
{
	 abstract class State
	{
        string _name;
        float _governmentBond;


        protected State(string Name, float GovernmentBond)
        {
            Name = _name;
            GovernmentBond = _governmentBond;
        }

        public string Name { get { return _name; } }
        public float GovernmentBond { get { return _governmentBond; } }

        public abstract void DisplayInformation();
    }

    class EuropeanState : State, IEuropeanCentralBank
    {

        bool _isEurozone;
 
        public EuropeanState(string name, float GovernmentBond, bool isEurozone) : base(name, GovernmentBond)
        {
            _isEurozone = isEurozone;
        }

        public bool IsEurozone { get { return _isEurozone; } }
        public string DisplayGovernmentBondValue()
        {
            return $"{Name} Government Bond Value: {GovernmentBond}";
        }

        public string CalculateSpread()
        {
            float bund = 0.3f;
            return $"{Name} spread: {GovernmentBond - bund}";
        }
        public override void DisplayInformation()
        {
            Console.WriteLine($"State: {Name}, Eurozone Member: {IsEurozone}");
        }
    }


    class NonEuropeanState : State, IEuropeanCentralBank
    {

      

        public NonEuropeanState(string name, float GovernmentBond) : base(name, GovernmentBond)
        {
    
        }


        public string DisplayGovernmentBondValue()
        {
            return $"This state is not european";
        }

        public string CalculateSpread()
        {
            
            return $"{Name} is not european";
        }
        public override void DisplayInformation()
        {
            Console.WriteLine($"{Name}");
        }
    }
}
