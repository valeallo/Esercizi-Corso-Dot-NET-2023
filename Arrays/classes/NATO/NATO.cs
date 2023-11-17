using Arrays.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays.classes.NATO
{
    internal class NATO : IPoliticalOrganization
    {
        public NATO()
        {
            new NATOState("Turkey", this);


        }
    }
}
