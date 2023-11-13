using System;
using System.Xml.Linq;


namespace Eurozone_Calculator
{

    // I chose not to create a EuropeanState/non EU class and an ONU class cause they dont have specific properties or interfaces right now so I used a variable instead, this could be implemented and can be requested
	 abstract class State
	{
        string _name;
        float _governmentBond;
        bool _isONUmember;
        bool _hasDeathPenalty;


        protected State(string Name, float GovernmentBond, bool IsONUmember, bool HasDeathPenalty)
        {
            _name = Name;
            _governmentBond = GovernmentBond;
            _isONUmember = IsONUmember;
            _hasDeathPenalty = HasDeathPenalty;
        }

        public string Name { get { return _name; } }
        public float GovernmentBond { get { return _governmentBond; } }

        public bool IsONUMember { get { return _isONUmember; } }
        public bool HasDeathPenalty { get { return _hasDeathPenalty; } }

        public abstract void DisplayInformation();
    }

    class EUState : State , IEuropeanHumanRightsCourt
    {

 
        public EUState(string Name, float GovernmentBond, bool IsONUMember) : base(Name, GovernmentBond, IsONUMember, false)
        {
            
        }

  
        public override void DisplayInformation()
        {
            Console.WriteLine($"State: {Name}, EU member");
        }


        public void IsStateRespectingHumanRights()
        {
            if (IsONUMember)
            {
                Console.WriteLine($"{Name} respects human rights and is an ONU member and a EU member.");
            }
            else
            {
                Console.WriteLine($"{Name} respects human rights and is EU member.");
            }
        }


    }


    class EurozoneState : EUState, IEuropeanCentralBank
    {

        public EurozoneState (string Name, float GovernmentBond, bool IsONUMember) : base(Name, GovernmentBond, IsONUMember){

        }

        public void DisplayGovernmentBondValue()
        {
            Console.WriteLine($"{Name} Government Bond Value: {GovernmentBond}");
        }

        public void CalculateSpread()
        {
            float bund = 0.3f;

            if (Name == "Germany")
            {
                bund = GovernmentBond;
            }
            Console.WriteLine($"{Name} spread: {GovernmentBond - bund}");
        }


    }


    class NonEuropeanState : State, IEuropeanHumanRightsCourt
    {

      

        public NonEuropeanState(string Name, float GovernmentBond, bool IsONUMember, bool HasDeathPenalty) : base(Name, GovernmentBond, IsONUMember, HasDeathPenalty)
        {
    
        }


        public override void DisplayInformation()
        {
            Console.WriteLine($"{Name} : Non EU member");
        }


        public void IsStateRespectingHumanRights()
        {
            if (HasDeathPenalty)
            {
                Console.WriteLine($"{Name} is not respecting human rights and has the death penalty.");
            }
            else if (IsONUMember)
            {
                Console.WriteLine($"{Name} respects human rights and is an ONU member");
            }
            else
            {
                Console.WriteLine($"{Name} respects human rights");
            }
        }
    }
}
