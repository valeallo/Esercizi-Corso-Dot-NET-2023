using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RealEstateAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            //posso andare a prendere i servizi e scegliere di creare un istanza


            using ( var scope = host.Services.CreateScope())
            {
                //dentro lo using ci possono stare solo classi che implemanteno Idisposable, ma non basta devo configurare il metodo dispose
                //dentro allo using alla fine del mio giro deve essere rilasciata/disposed 
                var services = scope.ServiceProvider;
                //per attivare il servizio ho bisogno del service provider
                //quando si lavora con il context SEMPRE dentro allo using
                var context = services.GetService<RealEstateContext>();
                using(var db = context)
                {
                    foreach(var item in db.Users.ToList())
                    {
                        Console.WriteLine(item.Name);
                        //vado a leggere dalla mia tabellla del mio db

                    }
                }
            }


           host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
