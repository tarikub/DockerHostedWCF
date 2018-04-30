using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using WCFClient.SampleService;

namespace WCFClient
{
    class Program
    {
        static void Main()
        {
            // Get a client for the service
            SampleServiceClient wcfClient = new SampleServiceClient();

            // Call the GetData method on the server
            string retstr = wcfClient.GetData(123);
            Console.WriteLine("GetData returns: " + retstr);

            // Create the CompositeType object from the service and execute 
            // the GetDataUsingDataContract method on the server
            CompositeType obj = new CompositeType();
            obj.BoolValue = true;
            obj.StringValue = "Hello WCF client";
            CompositeType objret = wcfClient.GetDataUsingDataContract(obj);

            Console.WriteLine("GetDataUsingDataContract returns: " + objret.StringValue);
            Console.ReadLine();

            // Close the connection to the server
            wcfClient.Close();
        }
    }
}
