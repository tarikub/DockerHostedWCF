using WCFServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace WCFHost
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the ServiceHost.
            using (ServiceHost host = new ServiceHost(typeof(SampleService)))
            {
                host.Open();
                var ipAddress = LocalIPAddress().ToString();
                var hostBaseInfo = host.BaseAddresses[0];
                var serviceAddress = String.Format("{0}://{1}:{2}/SampleService.svc/", hostBaseInfo.Scheme, ipAddress, hostBaseInfo.Port);
                Console.WriteLine("The Sample Service is ready.");
                Console.WriteLine("Update `app.config` on the client app (i.e. WCFClient) to use {0} as an endpoint address.", serviceAddress);
                while (true)
                {
                    // Just hang around until the container destroys the service
                    Thread.Sleep(1000);

                }
                // Close the ServiceHost - not really needed because Docker will destroy the host and us with it
                host.Close();
            }
            IPAddress LocalIPAddress()
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                var ipAddress = host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
                return ipAddress;
            }
        }
    }
}
