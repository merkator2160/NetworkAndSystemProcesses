using System;
using System.Threading;
using Unity.Wcf;

namespace Fifth.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean createdNew;

            var multyStartupProtection = new Mutex(true, "RemoteServiceManager", out createdNew);
            if (createdNew)
            {
                var host = new UnityServiceHost(UnityFactory.GetConfiguredContainer(), typeof(RemoteServiceManager));
                Console.Write("Starting service ...  ");
                try
                {
                    host.AddDefaultEndpoints();
                    host.Open();

                    Console.WriteLine("success!");
                    Console.WriteLine("Press any key to close the program.");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    //throw;
                    Console.ReadKey();
                }
                finally
                {
                    host.Abort();
                }
            }
        }
    }
}
