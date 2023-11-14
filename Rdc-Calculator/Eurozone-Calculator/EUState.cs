using System;
using System.Xml.Linq;


{
    class EUState : State, IEuropeanHumanRightsCourt
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
}
