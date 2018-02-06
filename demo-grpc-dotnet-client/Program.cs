using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hello.HelloSerivce;

namespace demo_grpc_dotnet_client
{
    class Program
    {
        const string REMOTE = "127.0.0.1:50051";
        static void Main(string[] args)
        {
            HelloClient();
        }
        static void HelloClient()
        {
            Channel channel = new Channel(REMOTE, ChannelCredentials.Insecure);

            var client = new HelloSerivceClient(channel);
            try { 
                var reply = client.tickInfo(new Hello.HelloRequest { Name = "hewe", Age = 44 });
                Console.WriteLine(string.Format("info: {0}, recieve time: {1}", reply.Info, reply.ReceiveTime));
            }
            catch(Grpc.Core.RpcException exce)
            {
                Console.WriteLine(exce.Message);
                
            

            channel.ShutdownAsync().Wait();
            Console.WriteLine("任意键退出...");
            Console.ReadKey();
        }
    }
}
