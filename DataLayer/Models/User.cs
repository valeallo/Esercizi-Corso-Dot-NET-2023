using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataLayer.Models
{
    public abstract class User
    {

        public string Name { get; set;  }
        public string Id { get; set; }
    }
}
