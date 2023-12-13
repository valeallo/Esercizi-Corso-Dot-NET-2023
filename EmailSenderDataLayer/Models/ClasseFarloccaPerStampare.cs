using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderDataLayer.Models
{
    public class ClasseFarloccaPerStampare 
    {
        private readonly MyServiceSettings _configuration;

        public ClasseFarloccaPerStampare(IOptions<MyServiceSettings> myserviceSetting)
        {
            _configuration = myserviceSetting.Value;
        }

        public void DoSomething()
        {
            Console.WriteLine();

            Console.WriteLine($"Intanza N : {MyServiceSettings.counter}");
            Console.WriteLine($"Valore di configurazione: {_configuration.Server}");
            Console.WriteLine($"Valore di configurazione: {_configuration.Proxy}");
            Console.WriteLine($"Valore di configurazione: {_configuration.IpAddress}");
            Console.WriteLine($"Valore di configurazione: {_configuration.Backend}");
            Console.WriteLine($"Valore di configurazione: {_configuration.Fontend}");
            Console.WriteLine($"Valore di configurazione: {_configuration.FilePath}");
        }
    }
}
