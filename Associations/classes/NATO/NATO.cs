using Associations.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations.classes.NATO
{
    internal class NATO : IPoliticalOrganization
    {
        public NATO()
        {
            new NATOState("Turkey", this);


        }
    }
}
