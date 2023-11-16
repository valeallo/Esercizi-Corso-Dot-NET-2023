using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Associations.classes.Default;

namespace Associations.classes.NATO
{
    internal class NATOState : State
    {
        NATO _nato;

        public NATOState(string Name, NATO Nato) : base(Name)
        {
            _nato = Nato;
        }
    }
}
