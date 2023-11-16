using Associations.classes.Default;
using Associations.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations.classes.UE
{
    internal class EURegion : GeographicalArea, IAdministrativeEntity
    {
        State _state;
        EUProvince _province;
        public EURegion(State state)
        {

            _state = state;
        }

        public void ChangeState(State state)
        {
            _state.RemoveRegion(this);
            _state = state;
        }

        public void AddProvince(EUProvince province)
        {
            _province = province;
        }

        public void RemoveProvince(EUProvince province)
        {
            _province = null;
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
