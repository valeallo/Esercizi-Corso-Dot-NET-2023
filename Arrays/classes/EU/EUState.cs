using Arrays.classes.Default;
using Arrays.interfaces;
using Arrays.interfaces.UE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays.classes.UE
{
    internal class EUState : State, IEuropeanUnion, IEUAdministrativeEntity
    {
        EuropeanUnion _europeanUnion;
        EURegion _europeanRegion;

        public EUState(string Name, EuropeanUnion EuropeanUnion) : base(Name)
        {
            _europeanUnion = EuropeanUnion;
        }


        public void EuropeanConstitutionalRegulation() 
        {
            Console.WriteLine("European constitution actions");
        
        }
        public void HumanRightsTribunal() 
        {
            Console.WriteLine("Human rights tribunal actions");

        }

        public void AddRegion(EUParliament EUParliament, EURegion region)
        {
            bool isApproved = EUParliament.ApproveChanges();
            if (isApproved)
            { 
               _europeanRegion = region;
                Console.WriteLine("region is added to state");
            
            }
            else
            {
                Console.WriteLine("not approved by eu");
            }

        }


        public void RemoveRegion(EUParliament EUParliament, EURegion region)
        {
            bool isApproved = EUParliament.ApproveChanges();
            if (isApproved)
            {
                _europeanRegion = null;
                Console.WriteLine("region is removed");

            } else
            {
                Console.WriteLine("not approved by eu");

            }


        }

        public void BorderRedefinition(EUParliament eUParliament) { }



        public void WelfareServices()
        {
            Console.WriteLine("using region welfare services");
        }
    }
}
