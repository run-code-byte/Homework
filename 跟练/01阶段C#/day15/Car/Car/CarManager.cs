using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Car
{
    internal class CarManager
    {
        private string Path { get; } = "./car.json";
        private JsonSerializerOptions JsonOpt { get; } = new JsonSerializerOptions()
        {
            WriteIndented = true,
            AllowTrailingCommas = true,
            Encoder=System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        //新增车辆
        public string Add(string card,string type,string price)
        {
            List<Car> cars = new();
            if (File.Exists(Path))
            {
                string jsonStr=File.ReadAllText(this.Path);
                cars=JsonSerializer.Deserialize<List<Car>>(jsonStr);
                if(cars.Exists(item=>item.Card==card)) return "新增失败,车牌已存在";
            }
            Car CAdd=new Car(cars.Count + 1, card, type, true, double.Parse(price));
            cars.Add(CAdd);
            string resStr=JsonSerializer.Serialize(cars, JsonOpt);
            File.WriteAllText(this.Path,resStr);
            return "新增车辆成功！！！";
        }
        //查看所有车辆信息
        public void SearchAll()
        {
            if(!File.Exists(this.Path))
            {
                Console.WriteLine("没有车辆消息，请先添加");
                return;
            }
            string jsonStr = File.ReadAllText(this.Path);
            List<Car> cars = JsonSerializer.Deserialize<List<Car>>(jsonStr);
            foreach (Car item in cars)
            {
                string statusStr = item.Status ? "空闲" : "已出租";
                Console.WriteLine($"id:{item.Id} -- 车牌：{item.Card} -- 类型：{item.Type} -- 状态：{statusStr} -- 时租费：{item.Price}");
            }
        }
        //查看某辆车
        public void SearchOne(int id)
        {
            if (!File.Exists(this.Path)) { 
                Console.WriteLine("没有车辆消息，请先添加");
                return;
            }
            string jsonStr = File.ReadAllText(this.Path);
            List<Car> cars = JsonSerializer.Deserialize<List<Car>>(jsonStr);
            Car carObj=cars.Find(item => item.Id == id);
            if (carObj == null)
            {
                Console.WriteLine("没有车辆消息，请先添加");
                return;
            }
            string statusStr = carObj.Status ? "空闲" : "已出租";
            Console.WriteLine($"id:{carObj.Id} -- 车牌：{carObj.Card} -- 类型：{carObj.Type} -- 状态：{statusStr} -- 时租费：{carObj.Price}");
            
        }
        //查看所有空闲车辆
        public void SearchFree()
        {
            if (!File.Exists(this.Path))
            {
                Console.WriteLine("没有车辆信息，请先添加");
                return;
            }
            string jsonStr = File.ReadAllText(this.Path);
            List<Car> cars = JsonSerializer.Deserialize<List<Car>>(jsonStr);
            List<Car> carsFree=cars.FindAll(item => item.Status);
            if (carsFree.Count == 0)
            {
                Console.WriteLine("没有空闲车辆信息，请先添加");
                return;
            }
            foreach (Car item in carsFree)
            {
                string statusStr = item.Status ? "空闲" : "已出租";
                Console.WriteLine($"id:{item.Id} -- 车牌：{item.Card} -- 类型：{item.Type} -- 时租费：{item.Price}");
            }
        }


        public (string,bool) UpdateStatus(int id)
        {
            if (!File.Exists(this.Path)) return ("暂无车辆！！！",false);
            
            string jsonStr = File.ReadAllText(this.Path);
            List<Car> cars = JsonSerializer.Deserialize<List<Car>>(jsonStr);
            Car carObj = cars.Find(item => item.Id == id);
            if (carObj == null) return ("没有对应ID的车辆！！！",false);
           if(!carObj.Status) return ("该车辆已被租出！！！",false);
            carObj.Status= false;
            string resStr = JsonSerializer.Serialize(cars, JsonOpt);
            File.WriteAllText(this.Path, resStr);
            return ("租车成功！！！",true);
        }
        
        public double UpAndGetInfo(int id)
        {
            string jsonStr = File.ReadAllText(this.Path);
            List<Car> cars = JsonSerializer.Deserialize<List<Car>>(jsonStr);
            Car carObj = cars.Find(item => item.Id == id);
            carObj.Status = true;
            string resStr = JsonSerializer.Serialize(cars, JsonOpt);
            File.WriteAllText(this.Path, resStr);
            return carObj.Price;
        }
    }
}
