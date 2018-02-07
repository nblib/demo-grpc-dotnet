using Grpc.Core;
using Jihe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hello.HelloSerivce;
using static Jihe.JiheService;

namespace demo_grpc_dotnet_client
{
    class Program
    {
        const string REMOTE = "127.0.0.1:50051";
        static void Main(string[] args)
        {
            //HelloClient();
            JiheClient();
        }
        /// <summary>
        /// hello 实例客户端,简单的使用
        /// </summary>
        static void HelloClient()
        {
            Channel channel = new Channel(REMOTE, ChannelCredentials.Insecure);

            //从连接中生成一个客户端
            var client = new HelloSerivceClient(channel);
            try
            {
                //调用方法
                var reply = client.tickInfo(new Hello.HelloRequest { Name = "hewe", Age = 44 });
                Console.WriteLine(string.Format("info: {0}, recieve time: {1}", reply.Info, reply.ReceiveTime));
            }
            catch (Grpc.Core.RpcException exce)
            {
                Console.WriteLine(exce.Message);
            }
            

            channel.ShutdownAsync().Wait();
            Console.WriteLine("任意键退出...");
            Console.ReadKey();
        }
        /// <summary>
        /// 测试集合的使用,包括list和map
        /// </summary>
       static void JiheClient()
        {

            Channel channel = new Channel(REMOTE, ChannelCredentials.Insecure);

            //从连接中生成一个客户端
            var client = new JiheServiceClient(channel);
            try
            {
                //模拟数据
                ListCar list = new ListCar();
                list.Car.Add(new Car { Id = 1001, Name = "救护车", Color = "white" });
                list.Car.Add(new Car { Id = 1002, Name = "消防车", Color = "red" });
                list.Car.Add(new Car { Id = 1003, Name = "垃圾车", Color = "green" });
                //调用方法
                var reply = client.transferToMap(list);
                //显示
                Console.WriteLine(string.Format("返回的数量为: {0}", reply.Cars.Count));
                //根据id获取一个
                var car = reply.Cars[1002];
                Console.WriteLine(string.Format("key: 1002, value: id={0},name={1},color={2}",car.Id,car.Name,car.Color));
            }
            catch (Grpc.Core.RpcException exce)
            {
                Console.WriteLine(exce.Message);
            }


            channel.ShutdownAsync().Wait();
            Console.WriteLine("任意键退出...");
            Console.ReadKey();
        }
    }
}
