using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataLayer.Models
{
    internal abstract class User
    {

        public string Name { get; set;  }
        public string Id { get; set; }
    }
}
