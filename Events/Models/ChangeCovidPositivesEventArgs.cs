using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events.Models
{
    internal class CovidPositivesChangedEventArgs : EventArgs
    {

        public int NewCovidPositives { get; }

        public CovidPositivesChangedEventArgs(int newCovidPositives)
        {
            NewCovidPositives = newCovidPositives;
        }
    }
}
