using Associations.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations
{
    internal class Region : GeographicalArea, IAdministrativeEntity
    {
        State _state;
        Province _province;
        public Region(State state) {
        
            _state = state;
        }
       
        public void ChangeState (State state)
        {
            _state.RemoveRegion(this);
            _state = state;
        }

        public void AddProvince (Province province)
        {
            _province = province;
        }

        public void RemoveProvince (Province province)
        {
            _province = null;
        }
    }
}
