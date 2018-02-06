using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;
using Hello;

namespace demo_grpc_dotnet_server.service
{
    public class HelloServiceImpl : HelloSerivce.HelloSerivceBase
    {
        public override Task<HelloReply> tickInfo(HelloRequest request, ServerCallContext context)
        {
            string tickinfo = String.Format("name= {0}, age= {1}", "hewe", "44");

            HelloReply reply = new HelloReply { Info = tickinfo, ReceiveTime = DateTime.Now.ToString() };
            return Task.FromResult(reply);
        }
    }
}
