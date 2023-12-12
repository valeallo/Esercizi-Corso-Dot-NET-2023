using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderDataLayer.Models
{
     public class Customer
    {
        internal string Id { get; set; }
        internal string Name { get; set; }
        internal string Email { get; set; }
        internal string Password { get; set; }
        internal int NumberOfPurchases { get; set; }
    }
}
