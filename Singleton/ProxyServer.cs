using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
     sealed class ProxyServer
    {
        public static ProxyServer _instance;
        static Random rnd = new Random();
        private string[] ipAddresses = new string[4];
        private static readonly object  _lock = new object();

        private ProxyServer() 
        {

            for (int i = 0; i < ipAddresses.Length; i++)
            {
                ipAddresses[i] = GetRandomIPAddress();
            }

        }

        public static ProxyServer GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock) 
                { 
                    if ( _instance == null )
                    {
                        _instance = new ProxyServer();
                    }
                }
 
            }
            return _instance;
        }

        public string GetRandomIPAddress()
        {
            int index = rnd.Next(ipAddresses.Length);
            return ipAddresses[index];
        }

        public string GetIPAddress(int num)
        {
            return ipAddresses[num];
        }

    }
}
