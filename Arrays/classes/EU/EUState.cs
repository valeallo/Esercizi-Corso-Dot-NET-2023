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
    internal partial class EUState : State, IEuropeanUnion, IEUAdministrativeEntity
    {
        EuropeanUnion _europeanUnion;
        private EURegion[] _europeanRegions;


        public EUState(string Name, EuropeanUnion EuropeanUnion) : base(Name)
        {
           int NumberOfRegions = 30;
            _europeanRegions =new EURegion[NumberOfRegions];
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
                int index = Array.FindIndex(_europeanRegions, m => m == null);
                if (index != -1)
                {
                    _europeanRegions[index] = region;
                    Console.WriteLine("province is added");
                }
                else
                {
                    Console.WriteLine("No available space to add a new municipality");
                }
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
             
                int indexToRemove = Array.IndexOf(_europeanRegions, region);

                if (indexToRemove != -1) 
                {
                 
                    EURegion[] newRegions = new EURegion[_europeanRegions.Length - 1]; 
                    for (int i = 0, j = 0; i < _europeanRegions.Length; i++)
                    {
                        if (i != indexToRemove)
                        {
                            newRegions[j++] = _europeanRegions[i];
                        }
                    }

                    _europeanRegions = newRegions;
                    Console.WriteLine("Region removed");
                }
                else
                {
                    Console.WriteLine("Region not found");
                }

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
