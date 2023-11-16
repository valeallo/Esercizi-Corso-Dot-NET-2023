using Associations.classes.Default;
using Associations.interfaces.UE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations.classes.UE
{
    internal class EUParliament 
    {

        public EUParliament() { }


        public bool ApproveChanges()
        {
            Random random = new Random();
            return random.Next(2) == 1;
        }

    }
}
