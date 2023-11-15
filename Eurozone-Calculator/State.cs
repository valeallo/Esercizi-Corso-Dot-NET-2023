using System;

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

}
