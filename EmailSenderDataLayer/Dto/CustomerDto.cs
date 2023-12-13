using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailSenderDataLayer.Interfaces;
using EmailSenderDataLayer.Models;

namespace EmailSenderDataLayer.Dto
{
    public class CustomerDto : IDto<Customer>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int NumberOfPurchases { get; set; }

        internal CustomerDto(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            Email = customer.Email;
            Password = customer.Password;
            NumberOfPurchases = customer.NumberOfPurchases;
        }

        public CustomerDto()
        {
        }


        public void initializeFromEntity(Customer customer)
        {
            if (customer == null)
            {
                throw new ArgumentNullException(nameof(customer));
            }

            Id = customer.Id;
            Name = customer.Name;
            Email = customer.Email;
            Password = customer.Password;
            NumberOfPurchases = customer.NumberOfPurchases;
        }

    }
}
