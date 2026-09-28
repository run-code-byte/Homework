using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Car
{
    internal class RentReturnClass
    {
        private string Path { get; } = "./rentreturn.json";
        private JsonSerializerOptions JsonOpt { get; } = new JsonSerializerOptions()
        {
            WriteIndented = true,
            AllowTrailingCommas = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        //新增 租车记录
        public void RentCar()
        {
            Console.WriteLine("请输入车辆ID：");
            int carid = int.Parse(Console.ReadLine());
            Console.WriteLine("请输入客户ID：");
            int userid = int.Parse(Console.ReadLine());
            UserManager UM=new UserManager();
            if(!UM.SearchOneById(userid))
            {
                Console.WriteLine("输入客户ID有误！！！");
                return;
            }
            CarManager CM=new CarManager();
            var (resStr,isUpdate) =CM.UpdateStatus(carid);
            if(!isUpdate)
            {
                Console.WriteLine(resStr);
                return;
            }
            List<RentReturn> rrList = new();
            if (File.Exists(this.Path))
            {
                string jsonStr = File.ReadAllText(this.Path);
                rrList = JsonSerializer.Deserialize<List<RentReturn>>(jsonStr);
            }
            int id = rrList.Count == 0 ? 1 : rrList[rrList.Count - 1].Id + 1;
            string rentTime = DateTime.Now.ToString();
            RentReturn RR=new RentReturn(id,carid,userid,rentTime,"",0);
            rrList.Add(RR);
            string jsonrrStr = JsonSerializer.Serialize(rrList, JsonOpt);
            File.WriteAllText(this.Path, jsonrrStr);
            Console.WriteLine(resStr);
        }
        // 还车操作记录
        public void ReturnCar()
        {
            Console.WriteLine("请输入租车记录ID");
            int id = int.Parse(Console.ReadLine());
            if (!File.Exists(this.Path))
            {
                Console.WriteLine("没有租车信息！！！");
                return;
            }
            string jsonStr = File.ReadAllText(this.Path);
            List<RentReturn>  rrList = JsonSerializer.Deserialize<List<RentReturn>>(jsonStr);
            RentReturn rrObj = rrList.Find(item => item.Id == id);
            if(rrObj == null)
            {
                Console.WriteLine("租车信息有误！！！");
                return;
            }
            if(rrObj.ReturnTime!="")
            {
                Console.WriteLine("该车辆已还！！！");
                return;
            }
            CarManager CM=new CarManager();
            double price=CM.UpAndGetInfo(rrObj.CarId);
            TimeSpan diff=DateTime.Now-DateTime.Parse(rrObj.RentTime);
            double payMoney=(double)diff.TotalHours * price;
            rrObj.PayMoney = payMoney;
            rrObj.ReturnTime = DateTime.Now.ToString();
            string jsonrrStr = JsonSerializer.Serialize(rrList, JsonOpt);
            File.WriteAllText(this.Path, jsonrrStr);
            Console.WriteLine("*****还车成功*****");
        }

        public void SearchAll()
        {
            if (!File.Exists(this.Path))
            {
                Console.WriteLine("没有租车信息！！！");
                return;
            }
            string jsonStr = File.ReadAllText(this.Path);
            List<RentReturn> rrList = JsonSerializer.Deserialize<List<RentReturn>>(jsonStr);
            if (rrList.Count == 0)
            {
                Console.WriteLine("没有租车信息！！！");
                return;
            }
            rrList.ForEach(item =>
            {
                Console.WriteLine($"租车记录ID：{item.Id} -- 车辆ID：{item.CarId} -- 客户ID：{item.UserId} -- 租赁时间：{item.RentTime} -- 还车时间：{item.ReturnTime} -- 租车费用ID：{item.PayMoney} ");
            });
        }
    }
}
