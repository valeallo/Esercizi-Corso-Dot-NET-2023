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
    internal class EURegion : IEUPublicAdministration
    {
        EUState _state;
        EUProvince _province;
        public EURegion(EUState state)
        {

            _state = state;
        }

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

        public void AddProvince(EUParliament EUParliament, EUProvince province)
        {
            bool isApproved = EUParliament.ApproveChanges();
            if (isApproved)
            {
                _province = province;
                Console.WriteLine("province is added");
            }
            else
            {
                Console.WriteLine("not approved by eu");
            }
        }



        public void WelfareServices()
        {
            Console.WriteLine("using region welfare services");
        }

        public void BorderRedefinition(EUParliament eUParliament) { }



        //border redefinition remove province
        public bool BorderRedefinition(EUParliament EUParliament, EUProvince Province)
        {
            bool isApproved = EUParliament.ApproveChanges();
            if (isApproved)
            {
                _province = null;
                Console.WriteLine("province is removed");
                return true;
            }
                Console.WriteLine("not approved by eu");
                return false;
            
        }


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
