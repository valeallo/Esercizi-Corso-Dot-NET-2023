using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    internal class Artist : User
    {

        public Album[] albums { get; set; }
        public string genre { get; set; }
    }
}
