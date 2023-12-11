using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Artist : User
    {

        public string albums { get; set; }
        public string genre { get; set; }
    }
}
