using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmailSenderDataLayer.DbContext;
using EmailSenderDataLayer.Repository;
using EmailSenderDataLayer.Dto;
using System.Reflection.Metadata.Ecma335;
using EmailSenderDataLayer.Models;

namespace EmailSenderServiceLayer
{
    public class CustomerService
    {


        static CustomerService instance;

        private readonly GenericRepository<Customer, CustomerDto, CustomerDto> customerRepository;


        


        CustomerService()
        {

            customerRepository = new GenericRepository<Customer, CustomerDto, CustomerDto>();
            
        }

        public static CustomerService GetInstance()
        {
            if (instance is null)
            {
                instance = new CustomerService();
            }
            return instance;
        }
        public List<CustomerDto> GetAllCostumers()
        {
            return customerRepository.GetAll();
        }


        public bool AddCustomer(CustomerDto customerDto)
        {
            try
            {
                
                customerRepository.Create(customerDto);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return false;
            }
        }





    }





}

