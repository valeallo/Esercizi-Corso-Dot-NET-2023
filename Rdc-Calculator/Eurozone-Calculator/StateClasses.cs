using System;
using System.Xml.Linq;


namespace Eurozone_Calculator
{
	 abstract class State
	{
        string _name;


        protected State(string Name)
        {
            Name = _name;
        }

        public string Name { get { return _name; } }

        public abstract void DisplayInformation();
    }

    class EuropeanState : State
    {

        bool _isEurozone;
 
        public EuropeanState(string name, bool isEurozone) : base(name)
        {
            _isEurozone = isEurozone;
        }

        public bool IsEurozone { get { return _isEurozone; } }

        public override void DisplayInformation()
        {
            Console.WriteLine($"State: {Name}, Eurozone Member: {IsEurozone}");
        }
    }
}
