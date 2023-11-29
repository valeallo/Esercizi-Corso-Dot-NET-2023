using System;
using System.Collections.Generic;

namespace Singleton
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = 3;
            ProxyServer proxy1 = ProxyServer.GetInstance();
            ProxyServer proxy2 = ProxyServer.GetInstance();

            List<string> ipAddressesFromProxy1 = new List<string>();
            List<string> ipAddressesFromProxy2 = new List<string>();

            for (int i = 0; i < N; i++)
            {
                ipAddressesFromProxy1.Add(proxy1.GetIPAddress(i));
                ipAddressesFromProxy2.Add(proxy2.GetIPAddress(i));
            }

            bool listsAreEqual = true;

            if (ipAddressesFromProxy1.Count == ipAddressesFromProxy2.Count)
            { 
                for (int i = 0; i < ipAddressesFromProxy1.Count; i++)
                {
                    if (ipAddressesFromProxy1[i] != ipAddressesFromProxy2[i])
                    {
                        listsAreEqual = false;
                        break;
                    }
                }
            }
            else
            {
           
                listsAreEqual = false;
            }


            if (listsAreEqual)
            {
                Console.WriteLine("Le liste sono uguali.");
            }
            else
            {
                Console.WriteLine("Le liste sono diverse.");
            }




        }
    }
}
