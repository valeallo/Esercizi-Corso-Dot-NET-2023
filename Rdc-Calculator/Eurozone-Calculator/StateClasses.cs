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

    class EUState : State
    {

 
        public EUState(string name, float GovernmentBond) : base(name, GovernmentBond)
        {
            
        }

  
        public override void DisplayInformation()
        {
            Console.WriteLine($"State: {Name}, EU member");
        }
    }


    class EurozoneState : EUState, IEuropeanCentralBank
    {

        public EurozoneState (string name, float GovernmentBond) : base(name, GovernmentBond){

        }

        public string DisplayGovernmentBondValue()
        {
            return $"{Name} Government Bond Value: {GovernmentBond}";
        }

        public string CalculateSpread()
        {
            float bund = 0.3f;
            return $"{Name} spread: {GovernmentBond - bund}";
        }

    }


    class NonEuropeanState : State
    {

      

        public NonEuropeanState(string name, float GovernmentBond) : base(name, GovernmentBond)
        {
    
        }


 
        public override void DisplayInformation()
        {
            Console.WriteLine($"{Name}");
        }
    }
}
