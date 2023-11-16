using Associations.classes.Default;
using Associations.interfaces;
using Associations.interfaces.UE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations.classes.UE
{
    internal class EURegion : GeographicalArea, IEUPublicAdministration
    {
        State _state;
        EUProvince _province;
        public EURegion(State state)
        {

            _state = state;
        }

        public void ChangeState(EUParliament EUParliament, State state)
        {
            bool isApproved = EUParliament.ApproveChanges();
            if (isApproved)
            {
                _state.RemoveRegion(this);
                _state = state;
                Console.WriteLine("state is changed");
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
