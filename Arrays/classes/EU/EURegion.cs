using Arrays.classes.Default;
using Arrays.interfaces;
using Arrays.interfaces.EU;
using Arrays.interfaces.UE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays.classes.UE
{
     internal partial class EUState
    {
        private sealed partial class EURegion : IEUPublicAdministration
        {
            private EUState _state;
            private EUProvince[] _provinces;

            public EURegion(EUState state, int provinceCapacity)
            {
                _state = state;
                _provinces = new EUProvince[provinceCapacity];
            }

            public int NumberOfProvinces { get { return _provinces.Length; } }


            public void ChangeState(EUParliament EUParliament, EUState state)
            {
                bool isApproved = EUParliament.ApproveChanges();
                if (isApproved)
                {
                    _state.RemoveRegion(EUParliament, this);
                    _state = state;
                    Console.WriteLine("state is changed");
                }
                else
                {
                    Console.WriteLine("not approved by eu");
                }
            }

            public bool AddProvince(EUParliament EUParliament, EUProvince province)
            {
                bool isApproved = EUParliament.ApproveChanges();
                if (isApproved)
                {
                    int index = Array.FindIndex(_provinces, p => p == null);
                    if (index != -1)
                    {
                        _provinces[index] = province;
                        Console.WriteLine("Province is added");
                        return false;

                    }
                    else
                    {
                        Console.WriteLine("No available space to add a new province");
                        return true;

                    }
                }
                else
                {
                    Console.WriteLine("Not approved by EU");
                    return false;

                }
            }



            public void RemoveProvince(EUParliament EUParliament, EUProvince provinceToRemove)
            {
                bool isApproved = EUParliament.ApproveChanges();
                if (isApproved)
                {

                    int index = Array.FindIndex(_provinces, p => p == provinceToRemove);
                    if (index != -1)
                    {
                        _provinces[index] = null;
                        Console.WriteLine("Province is removed");
                    }
                    else
                    {
                        Console.WriteLine("Province not found");
                    }
                }
                else
                {
                    Console.WriteLine("Not approved by EU");
                }
            }



            public void WelfareServices()
            {
                Console.WriteLine("using region welfare services");
            }

            public void BorderRedefinition(EUParliament eUParliament) { }




            public void HealthCareNationalSystem()
            {
                Console.WriteLine("region ue healthcare");

            }
            public void LawSystem()
            {
                Console.WriteLine("lawsystem region eu");

            }
            public void EducationalSystem()
            {
                Console.WriteLine("edusystem region eu");

            }
        }
    }
}
