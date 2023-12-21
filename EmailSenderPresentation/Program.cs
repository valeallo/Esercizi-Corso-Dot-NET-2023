using EmailSenderDataLayer.Dto;
using EmailSenderDataLayer.Models;
using EmailSenderDataLayer.Repository;
using EmailSenderServiceLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Options;
using EmailSenderDataLayer.DbContext;


namespace EmailSenderPresentation
{
    internal class Program
    {
        static void Main(string[] args)
        {



            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string dataPath = Path.Combine(baseDirectory, "data");

            var inMemorySettings = new Dictionary<string, string>
            {
                {"MyServiceSettings:FilePath", dataPath}
            };

            var inConnectionSettings = new Dictionary<string, string>
            {
                {"ConnectionStrings:CsvDatabase", dataPath}
            };


            //var configuration = new ConfigurationBuilder()
            //                        .SetBasePath(baseDirectory)
            //                        .AddJsonFile("appsettings.json")
            //                        .AddInMemoryCollection(inMemorySettings)
            //                        .Build();

            var configuration = new ConfigurationBuilder()
                                 .SetBasePath(baseDirectory)
                                 .AddJsonFile("appsettings.json")
                                 .Build();


            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IConfiguration>(configuration);
            serviceCollection.Configure<MyServiceSettings>(configuration.GetSection("MyServiceSettings"));
            serviceCollection.Configure<EmailSetting>(configuration.GetSection("EmailSettings"));
            serviceCollection.AddTransient<GenericDbContext<Customer, CustomerDto>>();
            serviceCollection.AddTransient<GenericRepository<Customer, CustomerDto, CustomerDto>>();
            serviceCollection.AddTransient<ClasseFarloccaPerStampare>();


            var serviceProvider = serviceCollection.BuildServiceProvider();

   
            var myService = serviceProvider.GetService<ClasseFarloccaPerStampare>();
            var myRepository = serviceProvider.GetService<GenericRepository<Customer, CustomerDto, CustomerDto>>();


            var costumerService = new CustomerService(myRepository);
            var dbContext = serviceProvider.GetService<GenericDbContext<Customer, CustomerDto>>();


            costumerService.GetAllCostumers();



            myService.DoSomething();
          


            


            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();


        }



      //  static void TestRepositoryMethods(GenericRepository<Customer, CustomerDto, CustomerDto> repository)
      //  {


      //      CustomerDto customerDto = new CustomerDto
      //      {
      //          Id = "9999999",
      //          Name = "maggiaaa",
      //          Email = "maggiaaa.lala@exammmmple.com",
      //          Password = "securepassword",
      //          NumberOfPurchases = 5
      //      };




      //      // Obtain an instance of CustomerService
      //// Replace with your actual method of obtaining the service instance

      //      // Add the customer and get the result
      //      //bool isCreated = customerService.AddCustomer(customerDto);

      //      // Print the result to the console
      //      if (isCreated)
      //      {
      //          Console.WriteLine("Customer created successfully.");
      //      }
      //      else
      //      {
      //          Console.WriteLine("Failed to create customer.");
      //      }

      //      // Create a CustomerDto for testing
      //      var newCustomer = new CustomerDto
      //      {
      //          Id = "18888",
      //          Name = "BlaBlarepository",
      //          Email = "johnREpo@example.com",
      //          Password = "password123",
      //          NumberOfPurchases = 0
      //      };

      //      // Test Create method
      //      bool created = repository.Create(newCustomer);
      //      Console.WriteLine($"Customer creation result: {created}");

      //      // Optionally, test other methods like GetAll, GetById, Update, DeleteById
      //      // ...
      //  }


        //static void SaraCode()
        //{
        //    var configuration = new ConfigurationBuilder()
        //   .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        //   .AddJsonFile("app.json")
        //   .Build();

        //    var emailSetting = new EmailSetting();
        //    configuration.GetSection("EmailSettings").Bind(emailSetting);
        //    var serviceProvider = new ServiceCollection()
        //    .Configure<EmailSetting>(options =>
        //    {
        //        options.Host = emailSetting.Host;
        //        options.Port = emailSetting.Port;
        //        options.Security = emailSetting.Security;
        //        options.Username = emailSetting.Username;
        //        options.Password = emailSetting.Password;
        //    })
        //    .AddSingleton<IOrderRepository, OrderRepository>()
        //    .AddSingleton<IEmailTemplate, EmailTemplate>()
        //    .AddSingleton<ISmtpMailClient, SmtpMailClient>()
        //    .AddSingleton<IEmailService, EmailService>()
        //    .AddSingleton<OrderService>()
        //    .BuildServiceProvider();


        //    var orderService = serviceProvider.GetRequiredService<OrderService>();
        //    var smtpMailClient = serviceProvider.GetRequiredService<ISmtpMailClient>();

        //    var order = new Order
        //    {
        //        Id = 1,
        //        CustomerName = "Sara Di Luca",
        //        CustomerMail = "saradluffy@outlook.it"
        //    };
        //    var order2 = new Order
        //    {
        //        Id = 2,
        //        CustomerName = "Audrey Hepburn",
        //        CustomerMail = "audreyhep@outlook.it"
        //    };
        //    orderService.PlaceOrder(order);
        //    orderService.PlaceOrder(order2);

        //}



    




        public class ProfCode {
        

        internal class ProgramProf
        {
            static void Bla(string[] args)
            {

                // 1 - Install Microsoft.Extensions.Options.ConfigurationExtensions


                // 2 - Configura IConfiguration
                var configuration = new ConfigurationBuilder()
                      .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                      .AddEnvironmentVariables()
                      .Build();

                // 3 - Configura il service provider
                var serviceCollection = new ServiceCollection();
                #region AddSingleton
                // registra l'oggetto IConfiguration nel container DI come singleton.
                // Questo significa che una singola istanza di IConfiguration verrà condivisa
                // in tutta l'applicazione.
                serviceCollection.AddSingleton<IConfiguration>(configuration);
                #endregion
                #region Deserializza il Config 
                serviceCollection.Configure<MyServiceSettings>(configuration.GetSection("MyServiceSettings"));
                #endregion
                #region AddTransient
                //La scelta di AddTransient implica una nuova istanza ad ogni richiesta.
                //Assicurati che questo comportamento sia adatto per il tuo EmailSender. 
                //Se, per esempio, EmailSender mantenesse stato o risorse(come una connessione di rete),
                //potresti voler considerare AddSingleton o AddScoped a seconda del tuo scenario
                //specifico.  
                serviceCollection.AddTransient<ClasseFarloccaPerStampare>();

                #endregion
                #region BuildServiceProvider
                //Il metodo BuildServiceProvider è utilizzato nelle applicazioni.NET per costruire un 
                // ServiceProvider, che è il container effettivo per la Dependency Injection(DI).
                // Questo container è responsabile della risoluzione delle dipendenze e della gestione
                // del ciclo di vita dei servizi registrati.Ecco come funziona in un contesto di 
                // applicazione .NET:  
                var serviceProvider = serviceCollection.BuildServiceProvider();

                #endregion

                // 4 - Esempio di utilizzo del servizio (Simulazione)
                var MyService1 = serviceProvider.GetService<ClasseFarloccaPerStampare>();
                MyService1.DoSomething();

                var MyService2 = serviceProvider.GetService<ClasseFarloccaPerStampare>();
                MyService2.DoSomething();
            }
        }




    }







}
    }

