using demo_grpc_dotnet_server.service;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_grpc_dotnet_server
{
    class Program
    {
        const int Port = 50051;
        static void Main(string[] args)
        {
            HelloTest();
        }
        static void HelloTest()
        {
            Server server = new Server
            {
                Services = { Hello.HelloSerivce.BindService(new HelloServiceImpl()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("gRPC server listening on port " + Port);
            Console.WriteLine("任意键退出...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
