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

 
        public EUState(string Name, float GovernmentBond, bool IsONUMember, bool HasDeathPenalty) : base(Name, GovernmentBond, IsONUMember, HasDeathPenalty)
        {
            
        }

  
        public override void DisplayInformation()
        {
            Console.WriteLine($"State: {Name}, EU member");
        }


        public string IsStateRespectingHumanRights()
        {
            if (HasDeathPenalty)
            {
                return $"{Name} is not respecting human rights and has the death penalty.";
            }
            else if (IsONUMember)
            {
                return $"{Name} respects human rights and is an ONU member and a EU member.";
            }
            else
            {
                return $"{Name} respects human rights and is EU member.";
            }
        }


    }


    class EurozoneState : EUState, IEuropeanCentralBank
    {

        public EurozoneState (string Name, float GovernmentBond, bool IsONUMember, bool HasDeathPenalty) : base(Name, GovernmentBond, IsONUMember, HasDeathPenalty){

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


    class NonEuropeanState : State, IEuropeanHumanRightsCourt
    {

      

        public NonEuropeanState(string Name, float GovernmentBond, bool IsONUMember, bool HasDeathPenalty) : base(Name, GovernmentBond, IsONUMember, HasDeathPenalty)
        {
    
        }


        public override void DisplayInformation()
        {
            Console.WriteLine($"{Name} : Non eu member");
        }


        public string IsStateRespectingHumanRights()
        {
            if (HasDeathPenalty)
            {
                return $"{Name} is not respecting human rights and has the death penalty.";
            }
            else if (IsONUMember)
            {
                return $"{Name} respects human rights and is an ONU member";
            }
            else
            {
                return $"{Name} respects human rights";
            }
        }
    }
}
