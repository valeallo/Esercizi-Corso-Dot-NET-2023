using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations
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
