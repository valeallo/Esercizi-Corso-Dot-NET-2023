using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations
{
    internal class Country : GeographicalArea
    {
        State _state;

        public Country() 
        {
           // new State(this);
        }

    }
}
