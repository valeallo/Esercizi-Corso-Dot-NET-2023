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
using Microsoft.Extensions.Configuration;
using System.IO.Pipes;
using Microsoft.Extensions.Options;

namespace EmailSenderServiceLayer
{
    public class CustomerService
    {


        static CustomerService instance;

        private readonly GenericRepository<Customer, CustomerDto, CustomerDto> _customerRepository;


     

        public CustomerService(GenericRepository<Customer, CustomerDto, CustomerDto> customerRepository)
        {
            _customerRepository = customerRepository;

        }

        //public static CustomerService GetInstance()
        //{
        //    if (instance is null)
        //    {
        //        instance = new CustomerService();
        //    }
        //    return instance;
        //}
        public List<CustomerDto> GetAllCostumers()
        {
            var customers = _customerRepository.GetAll();
            try  { 
            Console.WriteLine($"Nome Cliente{customers[0].Name}");
            } catch (Exception ex)
            {
                Console.WriteLine("nome client errroree", ex.Message);
            }
            return _customerRepository.GetAll();
        }


        public bool AddCustomer(CustomerDto customerDto)
        {
            try
            {
                
                _customerRepository.Create(customerDto);
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

