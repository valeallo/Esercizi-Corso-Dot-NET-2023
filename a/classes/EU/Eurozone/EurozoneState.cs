﻿using Arrays.interfaces;
using Arrays.interfaces.EU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays.classes.UE.Eurozone
{
    internal class EurozoneState : EUState, IEurozone
    {
        public EurozoneState(string Name, EuropeanUnion europeanUnion) : base(Name, europeanUnion)
        {

        }

        public void EuroRegulation()
        {
            Console.WriteLine("I use Euro!");
        }
    }
}
