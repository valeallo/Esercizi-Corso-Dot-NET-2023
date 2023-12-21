using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSenderDataLayer.Models
{
    public class MyServiceSettings
    {
        public static int counter;
        public string Server { get; set; }
        public string Proxy { get; set; }
        public string Fontend { get; set; }
        public string Backend { get; set; }
        public string FromAddress { get; set; }
        public string IpAddress { get; set; }
        public string FilePath { get; set; }

        public MyServiceSettings()
        {
            counter++;
        }
    }
}
