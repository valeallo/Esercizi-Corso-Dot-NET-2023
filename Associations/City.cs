using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations
{
    internal class City : GeographicalArea
    {
        Province _province;

        public City(Province province) 
        {
            _province = province;
            new Commune(_province, this);
        
        }
    }
}
