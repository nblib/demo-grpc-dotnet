using Jihe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grpc.Core;

namespace demo_grpc_dotnet_server.service
{
    public class JiheServiceImpl: JiheService.JiheServiceBase
    {
        public override Task<MapCar> transferToMap(ListCar request, ServerCallContext context)
        {
            //数量
            Console.WriteLine("数量: " + request.Car.Count);
            ////获取指定位置的Car
            if (request.Car.Count > 2)
            {
                var car = request.Car[1];
                Console.WriteLine(string.Format("id: {0},name: {1},color: {2}",car.Id,car.Name,car.Color));
            }
            //获取list
            var list = request.Car;
            //新建返回的map
            Jihe.MapCar map = new MapCar();
            //转换成map,以id为key,car为value
            foreach (Car car in list)
            {
                map.Cars.Add(car.Id, car);
            }
            //完成
            return Task.FromResult(map);
        }
    }
}
