using System;
using System.Xml.Linq;


namespace Eurozone_Calculator
{
	 abstract class State
	{
        string _name;
        float _governmentBond;
        bool _isONUmember;
        bool _hasDeathPenalty;


        protected State(string Name, float GovernmentBond, bool IsONUmember, bool HasDeathPenalty)
        {
            Name = _name;
            GovernmentBond = _governmentBond;
            _isONUmember = IsONUmember;
            _hasDeathPenalty = HasDeathPenalty;
        }

        public string Name { get { return _name; } }
        public float GovernmentBond { get { return _governmentBond; } }

        public bool IsONUMember { get { return _isONUmember; } }
        public bool HasDeathPenalty { get { return _hasDeathPenalty; } }

        public abstract void DisplayInformation();
    }

    class EUState : State
    {

 
        public EUState(string name, float GovernmentBond, bool IsONUMember, bool HasDeathPenalty) : base(name, GovernmentBond, IsONUMember, HasDeathPenalty)
        {
            
        }

  
        public override void DisplayInformation()
        {
            Console.WriteLine($"State: {Name}, EU member");
        }
    }


    class EurozoneState : EUState, IEuropeanCentralBank
    {

        public EurozoneState (string name, float GovernmentBond, bool IsONUMember, bool HasDeathPenalty) : base(name, GovernmentBond, IsONUMember, HasDeathPenalty){

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

      

        public NonEuropeanState(string name, float GovernmentBond, bool IsONUMember, bool HasDeathPenalty) : base(name, GovernmentBond, IsONUMember, HasDeathPenalty)
        {
    
        }


        public override void DisplayInformation()
        {
            Console.WriteLine($"{Name}");
        }
    }
}
