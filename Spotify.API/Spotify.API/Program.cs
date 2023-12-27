using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Spotify.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Common.Logger;
using Serilog.Core;
using Spotify.API.Repository;

namespace Spotify.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

      


            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<SpotifyContext>();
                var logger = services.GetService<ILogger<Program>>();



                using (var db = context)
                {
                    foreach (var item in db.Users.ToList())
                    {
                        try
                        {
                            Console.WriteLine(item.Username);
                            //vado a leggere dalla mia tabellla del mio db
                        }
                        catch (Exception ex)
                        {
                            logger.LogError(ex, "An error occurred while processing user {Username}", item.Username);
                        }
                    }
                }

            }


            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog(Common.Logger.SeriLogger.Configure)
                
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
