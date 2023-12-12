using EmailSenderDataLayer.Dto;
using EmailSenderDataLayer.Models;
using EmailSenderDataLayer.Repository;
using EmailSenderServiceLayer;
using System;
using System.IO;

namespace EmailSenderPresentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a CustomerDto instance
            CustomerDto customerDto = new CustomerDto
            {
                Id = "123555",
                Name = "Teststststst",
                Email = "johnn.doe@exammmmple.com",
                Password = "securepassword", 
                NumberOfPurchases = 5
            };


            var customerRepository = new GenericRepository<Customer, CustomerDto, CustomerDto>();
            TestRepositoryMethods(customerRepository);



            // Obtain an instance of CustomerService
            var customerService = CustomerService.GetInstance(); // Replace with your actual method of obtaining the service instance

            // Add the customer and get the result
            bool isCreated = customerService.AddCustomer(customerDto);

            // Print the result to the console
            if (isCreated)
            {
                Console.WriteLine("Customer created successfully.");
            }
            else
            {
                Console.WriteLine("Failed to create customer.");
            }

    
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();




        }





        static void TestRepositoryMethods(GenericRepository<Customer, CustomerDto, CustomerDto> repository)
        {
            // Create a CustomerDto for testing
            var newCustomer = new CustomerDto
            {
                Id = "18888",
                Name = "BlaBlarepository",
                Email = "johnREpo@example.com",
                Password = "password123",
                NumberOfPurchases = 0
            };

            // Test Create method
            bool created = repository.Create(newCustomer);
            Console.WriteLine($"Customer creation result: {created}");

            // Optionally, test other methods like GetAll, GetById, Update, DeleteById
            // ...
        }
    }
}
